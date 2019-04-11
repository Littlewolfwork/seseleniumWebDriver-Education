using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace csharp_example
{
    public class Application
    {
        private IWebDriver driver;

        private CheckoutPage checkoutpage;
        private MainPage mainpage;
        private ProductPage productpage;

        public Application()
        {
            driver = new ChromeDriver();
            checkoutpage = new CheckoutPage(driver);
            mainpage = new MainPage(driver);
            productpage = new ProductPage(driver);
        }

        public void Quit()
        {
            driver.Quit();
        }

        internal void AddNewProduct(String Href)
        {
            productpage.Open(Href).AddNewProduct();                     
        }


        internal String GetProductsHref()
        {
            return mainpage.Open().GetProductsHref();            
        }

        internal Int32 GetProductsQuantity()
        {
            return mainpage.Open().GetProductsQuantity();
        }

        internal Int32 GetChekoutSummary()
        {
            return checkoutpage.Open().GetChekoutSummary();
        }

        internal void DelProduct()
        {
            checkoutpage.Open().DelProduct();
        }
        
    }
}