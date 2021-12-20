using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebDriverBybit.Model
{
    class AssetsPage
    {
      
        
            private By _transferLocator = By.ClassName("operation-default-btn");
            private By _senderAccountLocator = By.CssSelector(".asset-transfer__account > .asset-transfer__account-wraper");
            private By _choiceSendAccountLocator = By.XPath("//div[text()='Spot Account']");
            private By _cashBeforeTransfDerLocator = By.CssSelector(".asset-transfer__account-wraper > .asset-transfer__account-value");
            private By _accountReceiveLocator = By.CssSelector(".asset-transfer__account  > .asset-transfer__account-wraper");
            private By _choiceReceiverLocator = By.XPath("//div[text()='Derivatives Account']");
            private By _coinLocator = By.CssSelector(".by-select-adv-selection-search-input");
            private By _choiceBTCLocator = By.CssSelector(".by-select-adv-item-option-content");
            private By _transferableAmountLocator = By.CssSelector(".by-input__inner");
            private By _confirmButtonLocator = By.ClassName("by-button--contained");
            private By _cashAfterTransfLocator = By.CssSelector(".asset-transfer__account-wraper > .asset-transfer__account-value");
            private By _marketsLocator = By.CssSelector("#HEADER-NAV > a.header__nav-item.header__nav-item-markets");
            private WebDriver _driver;
            private WebDriverWait _wait;

            public AssetsPage(WebDriver driver)
            {
                _driver = driver;
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            }

            public void Transfer()
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_transferLocator));
                _driver.FindElements(_transferLocator)[1].Click();
            }

            public void SenderAccount()
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_senderAccountLocator)).Click();

            }

            public void ChooseSenderAccount()
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_choiceSendAccountLocator));
                _driver.FindElements(_choiceSendAccountLocator)[1].Click();
            }

            public double CashBeforeTransfer()
            {
                
                return Convert.ToDouble(_driver.FindElements(_cashBeforeTransfDerLocator)[1].Text.Split(' ')[0]);
               

            }
            public void ReceiveAccount()
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_accountReceiveLocator));
                _driver.FindElements(_accountReceiveLocator)[1].Click();
            }

            public void ChooseReceiverAccount()
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_choiceReceiverLocator));
                _driver.FindElement(_choiceReceiverLocator).Click();
            }

            public void OpenChooseCoinType()
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_coinLocator));
                _driver.FindElement(_coinLocator).Click();
            }

            public void ChooseCoinType()
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_choiceBTCLocator));
                _driver.FindElements(_choiceBTCLocator)[3].Click();
            }

            public void ChooseTransferableAmount(double amount)
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_transferableAmountLocator));
                _driver.FindElement(_transferableAmountLocator).SendKeys(amount.ToString());

            }

            public void Confirm()
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_confirmButtonLocator));
                _driver.FindElement(_confirmButtonLocator).Click();
            }

            public double CashAmountAfterTransfer()
            {
                _wait.Until(ExpectedConditions.ElementIsVisible(_cashAfterTransfLocator));
                return Convert.ToDouble(_driver.FindElements(_cashAfterTransfLocator)[1].Text.Split(' ')[0]);
            }

            public MarketPage MoveToMarketPage()
            {

            _driver.Navigate().GoToUrl("https://testnet.bybit.com/data/markets/spot");
            return new MarketPage(_driver);
        }

            public void TransferOperation(out double before, out double after, double amount)
            {
                Transfer();
                SenderAccount();
                ChooseSenderAccount();
                before = CashBeforeTransfer();
                ReceiveAccount();
                ChooseReceiverAccount();
                OpenChooseCoinType();
                ChooseCoinType();
                ChooseTransferableAmount(amount);
                Confirm();
                Thread.Sleep(5000);
                Transfer();
                after = CashAmountAfterTransfer();
            }





        
    }
}
