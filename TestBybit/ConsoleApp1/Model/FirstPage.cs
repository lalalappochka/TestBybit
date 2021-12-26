using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebDriverBybit.Model
{
    class FirstPage
    {

        private By _loginLocator = By.ClassName("header-login");
        private WebDriver _driver;
        private WebDriverWait _wait;
        private By _assetsLocator = By.XPath("//span[text()='Assets']");
        private By _assetsActiveLocator = By.XPath("//*[text()='Spot Account']");
        private By _marketLocator = By.XPath("//div[@id='HEADER-NAV']//a[contains(text(),'Markets')]");
        //private By _iconLocator = By.ClassName("icon-profile");
        

        public FirstPage(WebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }


        public LoginPage MoveToLoginPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_loginLocator)).Click();
            return new LoginPage(_driver);
        }

        //public void IconCheck()
        //{
        //    _wait.Until(ExpectedConditions.ElementIsVisible(_iconLocator));
        //    _driver.FindElement(_iconLocator);

        //}

        public AssetsPage MoveToAssets()
        {
            //IconCheck();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_assetsLocator));
            _driver.FindElement(_assetsLocator).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_assetsActiveLocator)).Click();
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            return new AssetsPage(_driver);
        }

        public MarketPage MoveToMarketPage()
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            _wait.Until(ExpectedConditions.ElementToBeClickable(_marketLocator));
            _driver.FindElement(_marketLocator).Click();
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            return new MarketPage(_driver);
        }


    }
}
