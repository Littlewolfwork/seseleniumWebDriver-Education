using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace csharp_example
{
    internal class ProductPage : Page
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        internal ProductPage Open(String Href)
        {
            driver.Url = Href;
            return this;
        }

        internal void AddNewProduct()
        {
            wait.Until(ExpectedConditions.ElementExists(By.Name("add_cart_product")));
            if (driver.FindElements(By.Name("options[Size]")).Count > 0)
            {
                SelectElement SelectSize = new SelectElement(driver.FindElement(By.Name("options[Size]")));
                SelectSize.SelectByIndex(1);
            }

            driver.FindElement(By.Name("add_cart_product")).Click();
            System.Threading.Thread.Sleep(700);
        }




    }
}