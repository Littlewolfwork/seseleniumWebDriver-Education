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
        public void Basket()
        {
 
            driver.Url = "http://localhost/litecart";
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
            do
            {
                driver.FindElement(By.CssSelector("ul.listing-wrapper li:first-child")).Click();
                wait.Until(ExpectedConditions.ElementExists(By.Name("add_cart_product")));
                if (driver.FindElements(By.Name("options[Size]")).Count > 0)
                {
                    SelectElement SelectSize = new SelectElement(driver.FindElement(By.Name("options[Size]")));
                    SelectSize.SelectByIndex(1);
                }

                driver.FindElement(By.Name("add_cart_product")).Click();
                System.Threading.Thread.Sleep(700);
                driver.FindElement(By.Id("logotype-wrapper")).Click();
                wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));

            } while (Convert.ToInt32(driver.FindElement(By.CssSelector("span.quantity")).Text) < 3);
            driver.FindElement(By.Id("cart-wrapper")).Click();
            wait.Until(ExpectedConditions.TitleIs("Checkout | My Store"));
            do
            {
                IWebElement ProductsTable = driver.FindElement(By.ClassName("items"));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("remove_cart_item")));
                driver.FindElement(By.Name("remove_cart_item")).Click();
                wait.Until(ExpectedConditions.StalenessOf(ProductsTable));

            } while (driver.FindElements(By.Id("box-checkout-summary")).Count > 0);

        }


        [TearDown]
        public void stop()
        {
            driver.Quit();

            driver = null;
        }
    }
}

