using System;
using System.IO;
using System.Collections.ObjectModel;
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
        public void CheckNewWindow()
        {
            Random rand = new Random();
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            wait.Until(ExpectedConditions.TitleIs("Countries | My Store"));
            driver.FindElement(By.CssSelector(".dataTable a")).Click();
            wait.Until(ExpectedConditions.TitleIs("Edit Country | My Store"));
            IList < IWebElement > Links = driver.FindElements(By.ClassName("fa-external-link"));

            for (int i=0; i < Links.Count; i++)
            {
                string mainWindow = driver.CurrentWindowHandle;
                ReadOnlyCollection<string> oldWindows = driver.WindowHandles;
                Links[i].Click();
                string newWindow = wait.Until <string>((d) =>
                {
                    List<String> handles = new List<String>(driver.WindowHandles);
                    for (int j =0; j < oldWindows.Count; j++)
                    {
                        handles.Remove(oldWindows[j]);
                    }
                    if (handles.Count > 0)
                    {
                        return handles[0];
                    }
                    else
                    {
                        return null;
                    }
                });

                driver.SwitchTo().Window(newWindow);
                driver.Close();
                driver.SwitchTo().Window(mainWindow);
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

