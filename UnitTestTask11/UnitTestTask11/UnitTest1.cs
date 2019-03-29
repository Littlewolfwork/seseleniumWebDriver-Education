using System;
//using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
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
        public void RegistAndLogin()
        {
            driver.Url = "http://localhost/litecart/en/create_account";
            wait.Until(ExpectedConditions.TitleIs("Create Account | My Store"));
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            SelectElement CountrySelect = new SelectElement(driver.FindElement(By.Name("country_code")));
            driver.FindElement(By.Name("firstname")).SendKeys("firstname" + unixTimestamp);
            driver.FindElement(By.Name("lastname")).SendKeys("lastname" + unixTimestamp);
            driver.FindElement(By.Name("address1")).SendKeys("Street " + unixTimestamp);
            driver.FindElement(By.Name("postcode")).SendKeys("12345");
            driver.FindElement(By.Name("city")).SendKeys("TestCity");
            CountrySelect.SelectByValue("US");
            driver.FindElement(By.Name("email")).SendKeys("email" + unixTimestamp + "@test.com");
            driver.FindElement(By.Name("phone")).SendKeys("12345678");
            driver.FindElement(By.Name("password")).SendKeys("password");
            driver.FindElement(By.Name("confirmed_password")).SendKeys("password");
            driver.FindElement(By.Name("create_account")).Click();
            driver.Url = "http://localhost/litecart/en/logout";
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
            driver.FindElement(By.Name("email")).SendKeys("email" + unixTimestamp + "@test.com");
            driver.FindElement(By.Name("password")).SendKeys("password");
            driver.FindElement(By.Name("login")).Click();
            


















        }


        [TearDown]
        public void stop()
        {
            driver.Quit();

            driver = null;
        }
    }
}

