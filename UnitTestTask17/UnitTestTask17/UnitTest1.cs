using System;
using System.IO;
using System.Collections.ObjectModel;
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
        public void CheckLogsBrowser()
        {
            Random rand = new Random();
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));
            driver.Url = "http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1";
            wait.Until(ExpectedConditions.TitleIs("Catalog | My Store"));
            IList<IWebElement> ListA = driver.FindElements(By.CssSelector(".dataTable td:last-child a"));
            List<String> ListHref = new List<string>();
            for (int i = 0; i < ListA.Count; i++)
            {

                if (ListA[i].GetAttribute("href").Contains("product_id"))
                {
                    ListHref.Add(ListA[i].GetAttribute("href"));
                }
            }
            for (int i = 0; i < ListHref.Count; i++)
            {
                driver.Url = ListHref[i];
                foreach (LogEntry l in driver.Manage().Logs.GetLog("browser"))
                {
                    Console.WriteLine(l);
                    Console.WriteLine(i);

                }
                System.Threading.Thread.Sleep(1000);
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

