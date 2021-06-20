using AutomationPracticeBDD.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeBDD.Pages
{
    public class OrderConfirmationPage
    {

        private IWebDriver _WebDriver { get; }
        private string _PriceXpath = "//*[@id='center_column']/div/span/strong";
        private PriceHelper _priceHelper;
        private WaitHelper _fwait;

        public OrderConfirmationPage(IWebDriver webdriver)
        {
            this._WebDriver = webdriver;
            _priceHelper = new PriceHelper();
            _fwait = new WaitHelper(webdriver);
        }


        public double getChargedPrice() {


            IWebElement PriceAmount = _fwait.fluentWait(_PriceXpath);

            string PriceAmountText = PriceAmount.Text;

            double Price = _priceHelper.priceExtractor(PriceAmountText);

            return Price;

        }

    }
}
