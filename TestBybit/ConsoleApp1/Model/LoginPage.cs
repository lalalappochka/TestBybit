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
    class LoginPage
    {
        private By _emailLocator = By.CssSelector(".by-input-newui-field > .by-input-newui-field__input");
        private By _passwordLocator = By.CssSelector(".by-input-newui-field > .by-input-newui-field__input");
        private By _enterLocator = By.CssSelector(".log-newui-footer-submit");
        private WebDriverWait _wait;

        private WebDriver _driver;

        public LoginPage(WebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(100));

        }

        public void EnterEmail(String email)
        {
            _driver.FindElements(_emailLocator)[0].SendKeys(email);

        }

        public void EnterPassword(String password)
        {
            _driver.FindElements(_passwordLocator)[1].SendKeys(password);

        }

        public FirstPage EnterBut()
        {
            _driver.FindElements(_enterLocator)[0].Click();
            return new FirstPage(_driver);
        }

        public FirstPage LoginAs(string email, string password)
        {
            EnterEmail(email);
            EnterPassword(password);
            return EnterBut();
        }
    }
}
