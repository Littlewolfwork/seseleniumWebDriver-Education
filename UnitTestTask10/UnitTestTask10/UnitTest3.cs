using System;
//using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace csharp_example_ie
{
    [TestFixture]
    public class MyFirstTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private int[] SplitColor(string s)
        {
            s = s.Substring(5, s.Length - 6);
            string[] colorsStrings = s.Split(',');
            int[] colors = new int[4];
            for (int i = 0; i < colorsStrings.Length; i++)
            {
                colors[i] = Convert.ToInt32(colorsStrings[i]);
            }
            return colors;
        }
        private float ConverSize(string s)
        {
            s = s.Substring(0, s.Length - 2);
            float FontSize = Convert.ToSingle(s, System.Globalization.CultureInfo.InvariantCulture);
            return FontSize;
        }


        [SetUp]
        public void start()
        {
            driver = new InternetExplorerDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void AllStikersIE()
        {
            driver.Url = "http://localhost/litecart";
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
            String TextProductMain = driver.FindElement(By.CssSelector("#box-campaigns .name")).Text;
            String CampaignPriceMain = driver.FindElement(By.CssSelector("#box-campaigns .campaign-price")).Text;
            String RegularPriceMain = driver.FindElement(By.CssSelector("#box-campaigns .regular-price")).Text;
            String RegularPriceTagMain = driver.FindElement(By.CssSelector("#box-campaigns .regular-price")).GetAttribute("tagName");
            String RegularPriceColorMain = driver.FindElement(By.CssSelector("#box-campaigns .regular-price")).GetCssValue("color");
            int[] RegularPriceColorMainInt = SplitColor(RegularPriceColorMain);
            String CampaignPriceColorMain = driver.FindElement(By.CssSelector("#box-campaigns .campaign-price")).GetCssValue("color");
            int[] CampaignPriceColorMainInt = SplitColor(CampaignPriceColorMain);
            String CampaignPriceWeightMain = driver.FindElement(By.CssSelector("#box-campaigns .campaign-price")).GetCssValue("font-weight");
            int CampaignPriceWeightMainInt = Convert.ToInt32(CampaignPriceWeightMain);
            String CampaignPriceSizeMain = driver.FindElement(By.CssSelector("#box-campaigns .campaign-price")).GetCssValue("font-size");
            float CampaignPriceSizeMainInt = ConverSize(CampaignPriceSizeMain);
            String RegularPriceSizeMain = driver.FindElement(By.CssSelector("#box-campaigns .regular-price")).GetCssValue("font-size");
            float RegularPriceSizeMainInt = ConverSize(RegularPriceSizeMain);
            driver.FindElement(By.CssSelector("#box-campaigns a.link")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("box-product")));
            String TextProduct = driver.FindElement(By.CssSelector("#box-product h1.title")).Text;
            String CampaignPrice = driver.FindElement(By.CssSelector("#box-product .campaign-price")).Text;
            String RegularPrice = driver.FindElement(By.CssSelector("#box-product .regular-price")).Text;
            String RegularPriceTag = driver.FindElement(By.CssSelector("#box-product .regular-price")).GetAttribute("tagName");
            String RegularPriceColor = driver.FindElement(By.CssSelector("#box-product .regular-price")).GetCssValue("color");
            int[] RegularPriceColorInt = SplitColor(RegularPriceColor);
            String CampaignPriceColor = driver.FindElement(By.CssSelector("#box-product .campaign-price")).GetCssValue("color");
            int[] CampaignPriceColorInt = SplitColor(CampaignPriceColor);
            String CampaignPriceWeight = driver.FindElement(By.CssSelector("#box-product .campaign-price")).GetCssValue("font-weight");
            int CampaignPriceWeightInt = Convert.ToInt32(CampaignPriceWeight);
            String CampaignPriceSize = driver.FindElement(By.CssSelector("#box-product .campaign-price")).GetCssValue("font-size");
            float CampaignPriceSizeInt = ConverSize(CampaignPriceSize);
            String RegularPriceSize = driver.FindElement(By.CssSelector("#box-product .regular-price")).GetCssValue("font-size");
            float RegularPriceSizeInt = ConverSize(RegularPriceSize);

            Assert.True(TextProductMain == TextProduct);  // на главной странице и на странице товара совпадает текст названия товара
            Assert.True((RegularPriceTagMain == RegularPriceTag) && (CampaignPriceMain == CampaignPrice)); // на главной странице и на странице товара совпадают цены (обычная и акционная)
            Assert.True((RegularPriceTagMain == "S") && (RegularPriceColorMainInt[0] == RegularPriceColorMainInt[1] && RegularPriceColorMainInt[1] == RegularPriceColorMainInt[2]));  // обычная цена зачёркнутая и серая, главная страница 
            Assert.True((RegularPriceTag == "S") && (RegularPriceColorInt[0] == RegularPriceColorInt[1] && RegularPriceColorInt[1] == RegularPriceColorInt[2]));  // обычная цена зачёркнутая и серая, страница товара
            Assert.True((CampaignPriceWeightMainInt >= 700) && (CampaignPriceColorMainInt[1] == CampaignPriceColorMainInt[2]));  // акционная жирная и красная, главная страница  
            Assert.True((CampaignPriceWeightInt >= 700) && (CampaignPriceColorInt[1] == CampaignPriceColorInt[2]));  // акционная жирная и красная, главная страница  
            Assert.True(CampaignPriceSizeMainInt > RegularPriceSizeMainInt);   // акционная цена крупнее, чем обычная, главная страница
            Assert.True(CampaignPriceSizeInt > RegularPriceSizeInt);   // акционная цена крупнее, чем обычная, страница товара







        }


        [TearDown]
        public void stop()
        {
            driver.Quit();

            driver = null;
        }
    }
}

