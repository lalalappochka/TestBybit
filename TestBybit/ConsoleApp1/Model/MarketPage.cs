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

        private static string marketTypeXpath = "//span[contains(text()[1],'BTC') and contains(text()[3],'USDT')]";
        private static string favouritesXpath = "//span[contains(text(),'Избранное') or contains(text(),'Favorite')]";

        private By _spotLocator = By.XPath("//*[text()='Spot']"); 
        private By _marketTypeLocator = By.XPath(marketTypeXpath);
        private By _starButtonLocator = By.XPath(marketTypeXpath + "/../preceding-sibling::div");
        private By _FavoutiteLocator = By.XPath(favouritesXpath);
        private By _spotfavLocator = By.XPath(favouritesXpath + "/../../../following-sibling::div//span[contains(text(),'Спот')]");


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
            _driver.FindElement(_spotfavLocator).Click();
        }

        public string CheckFavourites()
        {
           return ( _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(marketTypeXpath)))).Text;
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
