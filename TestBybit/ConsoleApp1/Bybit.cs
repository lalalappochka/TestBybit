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
    class Bybit
    {
        public class Tests
        {
            private ChromeDriver chrome;
            private FirstPage firstPage;
            private AssetsPage assetsPage;
            private string pageURL = "https://testnet.bybit.com/";
            private string userEmail = "lalalappochka@gmail.com";
            private string userPassword = "P@ssw0rd";
            private double beforetrans;
            private double aftertrans;
            private double amount = 0.2;
            private string chooseMarket;
            private string favMarket;

     

            [OneTimeSetUp]
            public void Setup()
            {
                ChromeOptions options = new ChromeOptions();
                //options.AddArgument("user-data-dir=C:\\Users\\User\\AppData\\Local\\Google\\Chrome\\User Data");
                chrome = new ChromeDriver(options);
                chrome.Manage().Window.Maximize();
                chrome.Navigate().GoToUrl(pageURL);
                firstPage = new FirstPage(chrome);
                assetsPage = new AssetsPage(chrome);

            }

            [Test, Order(1)]
            public void BybitTestTransfer()
            {
                firstPage.MoveToLoginPage().LoginAs(userEmail, userPassword)
                    .MoveToAssets().TransferOperation(out beforetrans, out aftertrans, amount);
                Assert.AreEqual(aftertrans, beforetrans + amount);
                
            }



            [Test, Order(2)]
            public void ByBitTestFavourites()
            {
                assetsPage.MoveToMarketPage().ChooseFavouriteOperation(out chooseMarket, out favMarket);
                Assert.AreEqual(favMarket, chooseMarket);
                 

            }

            [OneTimeTearDown]
            public void Teardown()
            {
                chrome.Quit();
            }

        }
    }
}
