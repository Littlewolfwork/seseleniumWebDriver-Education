using System;
//using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;


namespace csharp_example
{
    [TestFixture]
    public class MyFirstTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void AllGeozonesOrder()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));
            System.Threading.Thread.Sleep(3000);
            driver.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
            IWebElement Table = wait.Until(ExpectedConditions.ElementExists(By.ClassName("dataTable")));
            IWebElement a;

            IList<IWebElement> ListTr = Table.FindElements(By.CssSelector("tr.row"));
            int size_ = ListTr.Count;
            List<String> ListUrl = new List<string>();
            List<String> ListZones = new List<string>();
            string TempStr;
            String CurrentStr;
            SelectElement TempSelect;
            for (int i = 0; i < size_; i++)
            {

                a = ListTr[i].FindElement(By.CssSelector("td:nth-child(3) a"));
                ListUrl.Add(a.GetAttribute("href"));

            }


            int CountUrl = ListUrl.Count;
            for (int i = 0; i < CountUrl; i++)
            {
                driver.Url = ListUrl[i];
                Table = wait.Until(ExpectedConditions.ElementExists(By.Id("table-zones")));
                ListTr = Table.FindElements(By.TagName("tr"));
                size_ = ListTr.Count;
                for (int j = 1; j < size_ - 1; j++)
                {
                    if (j < (size_ - 1))
                    {
                        TempSelect = new SelectElement(ListTr[j].FindElement(By.CssSelector("td:nth-child(3)")).FindElement(By.TagName("select")));
                        ListZones.Add(TempSelect.SelectedOption.Text);
                    }
                    else
                    {
                        continue;
                    }
                }

                for (int q = 0; q < ListZones.Count - 1; q++)
                {
                    Assert.True(String.Compare(ListZones[q], ListZones[q + 1]) <= 0);
                }
                ListZones.Clear();
            }
        }


        [TearDown]
        public void stop()
        {
            driver.Quit();

            driver = null;
        }
    }
}