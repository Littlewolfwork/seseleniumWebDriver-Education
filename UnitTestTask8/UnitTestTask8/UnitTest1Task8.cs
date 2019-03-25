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
        public void AllStikers()
        {
            driver.Url = "http://localhost/litecart";
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));

            IWebElement Tab = wait.Until(ExpectedConditions.ElementExists(By.ClassName("middle")));
            IList<IWebElement> ListImages = Tab.FindElements(By.ClassName("product"));
            int size_ = ListImages.Count;

            for (int i = 0; i < size_; i++)
            {
                Assert.IsTrue(ListImages[i].FindElements(By.ClassName("sticker")).Count == 1);               
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

