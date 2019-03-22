using System;
//using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

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

            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));

            IWebElement UlMain = wait.Until(ExpectedConditions.ElementExists(By.Id("box-apps-menu")));
            IList<IWebElement> ListItems = UlMain.FindElements(By.TagName("li"));
            int size_ = ListItems.Count;
            ListItems[0].Click();
            UlMain = wait.Until(ExpectedConditions.ElementExists(By.Id("box-apps-menu")));
            ListItems = UlMain.FindElements(By.CssSelector("#box-apps-menu>li"));
            IWebElement Main = wait.Until(ExpectedConditions.ElementExists(By.Id("content")));
            for (int i = 0; i < size_; i++)
            {
                Assert.True(Main.FindElements(By.TagName("h1")).Count > 0);
                if (ListItems[i].FindElements(By.TagName("ul")).Count > 0)
                {
                    IList<IWebElement> ListItemsNested = ListItems[i].FindElement(By.TagName("ul")).FindElements(By.TagName("li"));
                    int NestedSize_ = ListItemsNested.Count;
                    ListItemsNested[0].Click();
                    UlMain = wait.Until(ExpectedConditions.ElementExists(By.Id("box-apps-menu")));
                    ListItems = UlMain.FindElements(By.CssSelector("#box-apps-menu>li"));
                    ListItemsNested = ListItems[i].FindElement(By.TagName("ul")).FindElements(By.TagName("li"));
                    IWebElement MainNested = wait.Until(ExpectedConditions.ElementExists(By.Id("content")));
                    for (int j = 0; j < NestedSize_; j++)
                    {
                        Assert.True(MainNested.FindElements(By.TagName("h1")).Count > 0);
                        if (j < (NestedSize_ - 1))
                        {
                            ListItemsNested[j + 1].Click();
                        }
                        else
                        {
                            continue;
                        }
                        UlMain = wait.Until(ExpectedConditions.ElementExists(By.Id("box-apps-menu")));
                        ListItems = UlMain.FindElements(By.CssSelector("#box-apps-menu>li"));
                        ListItemsNested = ListItems[i].FindElement(By.TagName("ul")).FindElements(By.TagName("li"));
                        MainNested = wait.Until(ExpectedConditions.ElementExists(By.Id("content")));

                    }
                }

                //ListItems[i + 1].FindElement(By.TagName("a")).Click();
                if (i < (size_ - 1))
                {
                    ListItems[i + 1].Click();
                }
                else
                {
                    continue;
                }
                UlMain = wait.Until(ExpectedConditions.ElementExists(By.Id("box-apps-menu")));
                Main = wait.Until(ExpectedConditions.ElementExists(By.Id("content")));
                ListItems = UlMain.FindElements(By.CssSelector("#box-apps-menu>li"));
                //ListItems = UlMain.FindElements(By.TagName("li"));

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