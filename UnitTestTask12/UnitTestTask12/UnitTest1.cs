using System;
using System.IO;
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
        public void AddNewProduct()
        {
            Random rand = new Random();
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));
            driver.FindElement(By.CssSelector("#box-apps-menu li:nth-child(2) a")).Click();
            wait.Until(ExpectedConditions.TitleIs("Catalog | My Store"));
            driver.FindElement(By.Id("content")).FindElement(By.CssSelector("a.button:last-child")).Click();
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@name='status' and @value='1']")).Click();
            int code = rand.Next(1000);
            string StrProduct = "product " + code;
            driver.FindElement(By.Name("name[en]")).SendKeys(StrProduct);
            driver.FindElement(By.Name("code")).SendKeys(Convert.ToString(code));
            driver.FindElement(By.Name("quantity")).Clear();
            driver.FindElement(By.Name("quantity")).SendKeys("10");
            driver.FindElement(By.Name("new_images[]")).SendKeys(Directory.GetCurrentDirectory() + "\\duck.png");
            driver.FindElement(By.CssSelector(".tabs li:nth-child(2) a")).Click();
            System.Threading.Thread.Sleep(2000);
            SelectElement ManufacturerSelect = new SelectElement(driver.FindElement(By.Name("manufacturer_id")));
            ManufacturerSelect.SelectByValue("1");
            driver.FindElement(By.Name("short_description[en]")).SendKeys(StrProduct);
            driver.FindElement(By.Name("description[en]")).SendKeys(StrProduct);
            driver.FindElement(By.Name("head_title[en]")).SendKeys(StrProduct);
            driver.FindElement(By.CssSelector(".tabs li:nth-child(4) a")).Click();
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Name("purchase_price")).Clear();
            driver.FindElement(By.Name("purchase_price")).SendKeys("100");
            SelectElement CurrencySelect = new SelectElement(driver.FindElement(By.Name("purchase_price_currency_code")));
            CurrencySelect.SelectByValue("USD");
            driver.FindElement(By.Name("save")).Click();



        }


        [TearDown]
        public void stop()
        {
            driver.Quit();

            driver = null;
        }
    }
}

