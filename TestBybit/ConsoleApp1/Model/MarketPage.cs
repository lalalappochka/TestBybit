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
        private By _spotLocator = By.XPath("//*[text()='Spot']"); 
        private By _marketTypeLocator = By.CssSelector("//span[text()='BIT''/''USDT']");
        private By _starButtonLocator = By.ClassName("markets-tbody__row-collect");
        private By _FavoutiteLocator = By.CssSelector(".markets-nav__item > .f-14 >.nowrap");
        private By _spotfavLocator = By.CssSelector(".markets-tab__item > .f-12 > .nowrap");
        private By _FavAddLocator = By.CssSelector(".markets-tbody__item > .f-14 > .nowrap > .markets-tbody__item-symbol");


        public MarketPage(WebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(100));
        
        }

        public void ChooseSpot()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_spotLocator));
            _driver.FindElements(_spotLocator)[1].Click();

        }

        public string ChooseMarket()
        {
          return  _wait.Until(ExpectedConditions.ElementToBeClickable(_marketTypeLocator)).Text;
           
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

        public string CheckFavourites()
        {
           return ( _wait.Until(ExpectedConditions.ElementToBeClickable(_FavAddLocator))).Text;
          
        }

        public void ChooseFavouriteOperation(out string choosemarket, out string favmarket)
        {
            ChooseSpot();
          choosemarket = ChooseMarket();
            AddToFavourites();
            Favourite();
            ChooseSpotFav();
          favmarket = CheckFavourites();
        }

    }
}
