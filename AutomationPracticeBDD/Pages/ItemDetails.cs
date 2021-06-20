using AutomationPracticeBDD.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomationPracticeBDD.Pages
{
    public class ItemDetails
    {


        private IWebDriver _WebDriver { get; }
        private WaitHelper _fwait;
        private PriceHelper _priceHelper;
        private string _AddtoCartButtonXpath = "//*[@id='add_to_cart']/button/span";
        private string _ContinueShoppingXpath = "/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/span/span";
        private string _ItemPriceXpath = "//*[@id='our_price_display']";


        public ItemDetails(IWebDriver webdriver)
        {
            this._WebDriver = webdriver;

            _fwait = new WaitHelper(_WebDriver);
            _priceHelper = new PriceHelper();
        }

        public ItemDetails clickAddtoCartButton()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)_WebDriver;
            
            js.ExecuteScript(String.Format("window.scrollTo({0}, {1})", 0, 120));

            IWebElement addtoCartButton = _fwait.fluentWait(_AddtoCartButtonXpath);

            addtoCartButton.Click();

            return this;
        }

        public ItemDetails clickContinueShopping()
        {

            _WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement continueShoppingButton = _fwait.fluentWait(_ContinueShoppingXpath);

            continueShoppingButton.Click();

            return this;
        }

        public double getItemPrice()
        {

            WebDriverWait wait = new WebDriverWait(_WebDriver, TimeSpan.FromSeconds(10));

            // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(_)));

            //    _WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement ItemPriceElement = _fwait.fluentWait(_ItemPriceXpath);

            string ItemPriceText = ItemPriceElement.Text;

            double ItemPrice = _priceHelper.priceExtractor(ItemPriceText);

            return ItemPrice;
        }

    }
}
