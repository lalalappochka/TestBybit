using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.Threading;
using WebDriverBybit.Model;

namespace WebdriverBybit
{
    class Program
    {
        public class Tests
        {
            private ChromeDriver chrome;
            private FirstPage firstPage;
            private string pageURL = "https://testnet.bybit.com/";
            private string userEmail = "lalalappochka@gmail.com";
            private string userPassword = "P@ssw0rd";
            private double beforetrans;
            private double aftertrans;
            private double amount = 0.2;

            private IWebDriver driver;
            WebDriverWait wait;

            [OneTimeSetUp]
            public void Setup()
            {
                ChromeOptions options = new ChromeOptions();
                //options.AddArgument("user-data-dir=C:\\Users\\User\\AppData\\Local\\Google\\Chrome\\User Data");
                chrome = new ChromeDriver(options);
                chrome.Manage().Window.Maximize();
                chrome.Navigate().GoToUrl(pageURL);
                firstPage = new FirstPage(chrome);

            }

            [Test]
            public void BybitTest()
            {
                firstPage.MoveToLoginPage().LoginAs(userEmail, userPassword)
                    .MoveToAssets().TransferOperation(out beforetrans, out aftertrans, amount);
                Assert.AreEqual(beforetrans + amount, aftertrans);
                chrome.Quit();
            }

           

            //[Test]
            //public void ByBitFavourites()
            //{

            //    driver = new ChromeDriver();
            //    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            //    driver.Manage().Window.Maximize();
            //    pageURL = "https://testnet.bybit.com/data/markets/spot";
            //    driver.Navigate().GoToUrl(pageURL);
            //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            //    IWebElement Spot = driver.FindElements(By.ClassName("markets-nav__item f-14 nowrap"))[2];
            //    Spot.Click();
            //    IWebElement Market = driver.FindElements(By.ClassName("markets-tbody__item f-14 nowrap markets-tbody__item-symbol"))[0];
            //    IWebElement StarButton = driver.FindElements(By.ClassName("markets-tbody__row-collect"))[0];
            //    StarButton.Click();
            //    IWebElement Favourite = driver.FindElements(By.ClassName("markets-nav__item f-14 nowrap"))[0];
            //    Favourite.Click();
            //    IWebElement SpotType = driver.FindElements(By.ClassName("markets-tab__item f-12 nowrap"))[1];
            //    SpotType.Click();
            //    IWebElement FavMarket = driver.FindElement(By.ClassName(""));
            //    Assert.AreEqual(Market, FavMarket);


            //}

        }
    }
}
