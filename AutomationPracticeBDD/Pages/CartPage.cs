using AutomationPracticeBDD.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeBDD.Pages
{
    public class CartPage
    {
        private IWebDriver _WebDriver { get; }
        private WaitHelper _fwait;
        private PriceHelper _priceHelper;

        private string _DeleteButtonXpath = "/html/body/div/div[2]/div/div[3]/div/div[2]/table/tbody/tr[1]/td[7]/div/a/i";
        private string _ProductQuantityXpath = "//*[@id='summary_products_quantity']";
        private string _ProceedtoCheckoutXpath = "//*[@id='center_column']/p[2]/a[1]/span";
        public CartPage(IWebDriver webdriver)
        {
            this._WebDriver = webdriver;
            _fwait = new WaitHelper(_WebDriver);
            _priceHelper = new PriceHelper();
        }

        public CartPage clickDeleteItem() {

            IWebElement DeleteButton = _fwait.fluentWait(_DeleteButtonXpath);

            DeleteButton.Click();

            return this;
        }

        public double getCurrentProductQuantity() {

            IWebElement CurrentProdQuantity = _fwait.fluentWait(_ProductQuantityXpath);

            string ProdQuantityText = CurrentProdQuantity.Text;

            double currentAmount = _priceHelper.numberExtractor(ProdQuantityText);

            return currentAmount;
        }

        public AddressPage clickProceedtoCheckout() {

            _fwait.fluentWait(_ProductQuantityXpath);

            IJavaScriptExecutor js = (IJavaScriptExecutor)_WebDriver; js.ExecuteScript(String.Format("window.scrollTo({0}, {1})", 0, 200));

            IWebElement ProceedtoCheckoutButton = _fwait.fluentWait(_ProceedtoCheckoutXpath);

            ProceedtoCheckoutButton.Click();

            return new AddressPage(_WebDriver);
        }





    }
}
