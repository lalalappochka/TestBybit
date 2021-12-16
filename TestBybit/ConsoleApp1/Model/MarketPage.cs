using System;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace WebDriverBybit.Model
{
    class MarketPage
    {
        private WebDriverWait _wait;
        private WebDriver _driver;
        public MarketPage(WebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(100));
        }


    }
}
