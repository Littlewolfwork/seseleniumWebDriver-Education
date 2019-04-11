using System;
using OpenQA.Selenium;

namespace csharp_example
{
    internal class MainPage : Page
    {
        public MainPage(IWebDriver driver) : base(driver) { }

        internal MainPage Open()
        {
            driver.Url = "http://localhost/litecart";
            return this;
        }

        internal  String GetProductsHref()
        {
            return driver.FindElement(By.CssSelector("ul.listing-wrapper li:first-child  a.link")).GetAttribute("href");
        }

        internal Int32 GetProductsQuantity()
        {
            return Convert.ToInt32(driver.FindElement(By.CssSelector("span.quantity")).Text);
        }





    }
}