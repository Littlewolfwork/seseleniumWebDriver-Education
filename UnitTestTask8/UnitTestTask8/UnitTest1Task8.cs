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
        public void AllItemsLeftMenu()
        {
            driver.Url = "http://localhost/litecart";
            wait.Until(ExpectedConditions.TitleIs("My Store | Online Store"));

            IWebElement Tab = wait.Until(ExpectedConditions.ElementExists(By.ClassName("tab-content")));
            IList<IWebElement> ListImages = Tab.FindElements(By.ClassName("image-wrapper"));
            int size_ = ListImages.Count;
           // ListItems[0].Click();
            //UlMain = wait.Until(ExpectedConditions.ElementExists(By.Id("box-apps-menu")));
            //ListItems = UlMain.FindElements(By.CssSelector("#box-apps-menu>li"));
            //IWebElement Main = wait.Until(ExpectedConditions.ElementExists(By.Id("main")));
            for (int i = 0; i < size_; i++)
            {
                Assert.IsTrue(ListImages[i].FindElements(By.ClassName("sticker")).Count > 0);               
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

