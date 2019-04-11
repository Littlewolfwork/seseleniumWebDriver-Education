using System;
using System.Linq;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace csharp_example
{
    internal class CheckoutPage : Page
    {
        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        internal CheckoutPage Open()
        {
            driver.Url = "http://localhost/litecart/en/checkout";
            return this;
        }

        internal Int32 GetChekoutSummary()
        {
            return driver.FindElements(By.Id("box-checkout-summary")).Count;
        }

        internal void DelProduct()
        {
            IWebElement ProductsTable = driver.FindElement(By.ClassName("items"));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("remove_cart_item")));
            driver.FindElement(By.Name("remove_cart_item")).Click();
            wait.Until(ExpectedConditions.StalenessOf(ProductsTable));
        }

        /*   [FindsBy(How = How.CssSelector, Using = "table.dataTable tr.row")]
           IList<IWebElement> customerRows;

           internal ISet<string> GetCustomerIds()
           {
               return new HashSet<string>(
                   customerRows.Select(e => e.FindElements(By.TagName("td"))[2].Text).ToList());
           }*/
    }
}