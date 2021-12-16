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
        private By _spotLocator = By.ClassName("markets-nav__item f-14 nowrap");
        private By _marketTypeLocator = By.ClassName("markets-tbody__item f-14 nowrap markets-tbody__item-symbol");
        private By _starButtonLocator = By.ClassName("markets-tbody__row-collect");
        private By _FavoutiteLocator = By.ClassName("markets-nav__item f-14 nowrap");
        private By _spotfavLocator = By.ClassName("markets-tab__item f-12 nowrap");
        private By _spotFavLocator = By.ClassName("");


        public MarketPage(WebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(100));
        
        }

        public void ChooseSpot()
        {
            _driver.FindElements(_spotLocator)[2].Click();
        }

        public void ChooseMarket()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_marketTypeLocator));
            _driver.FindElements(_marketTypeLocator)[0].Click();
        }

        public void AddToFavourites()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_starButtonLocator));
            _driver.FindElements(_starButtonLocator)[0].Click();
        }

        public void Favourite()
        {
            _driver.FindElements(_FavoutiteLocator)[0].Click();
        }

        public void ChooseSpotFav()
        {
            _driver.FindElements(_spotfavLocator)[1].Click();
        }




    }
}
