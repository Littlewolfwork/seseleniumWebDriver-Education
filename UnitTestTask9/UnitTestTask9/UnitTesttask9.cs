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
        public void AllCountriesOrder()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));
            System.Threading.Thread.Sleep(3000);
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            IWebElement Table = wait.Until(ExpectedConditions.ElementExists(By.ClassName("dataTable")));
            IWebElement a;
            IList<IWebElement> ListTr = Table.FindElements(By.TagName("tr"));
            int size_ = ListTr.Count;
            // ListTr[0].GetAttribute("")
            List<String> ListUrl = new List<string>();
            string TempStr;
            String CurrentStr;
            for (int i = 1; i < size_ - 1; i++)
            {
                if (Convert.ToInt32(ListTr[i].FindElement(By.CssSelector("td:nth-child(6)")).Text) > 0)
                {
                    a = ListTr[i].FindElement(By.CssSelector("td:nth-child(5) a"));
                    ListUrl.Add(a.GetAttribute("href"));
                }
                if (i < (size_ - 2))
                {
                    TempStr = ListTr[i + 1].FindElement(By.CssSelector("td:nth-child(5)")).Text;
                }
                else
                {
                    continue;
                }
                CurrentStr = ListTr[i].FindElement(By.CssSelector("td:nth-child(5)")).Text;
                Assert.True(String.Compare(CurrentStr, TempStr) <= 0);
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
                    if (j < (size_ - 2))
                    {
                        TempStr = ListTr[j + 1].FindElement(By.CssSelector("td:nth-child(3)")).Text;
                    }
                    else
                    {
                        continue;
                    }
                    CurrentStr = ListTr[j].FindElement(By.CssSelector("td:nth-child(3)")).Text;
                  Assert.True(String.Compare(CurrentStr, TempStr) <= 0);

                }
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

