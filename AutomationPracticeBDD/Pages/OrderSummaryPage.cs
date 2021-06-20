using AutomationPracticeBDD.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeBDD.Pages
{
    public class OrderSummaryPage
    {


        private IWebDriver _WebDriver { get; }
        private string _ICormMyOrderXpath = "//*[@id='cart_navigation']/button/span";
        private WaitHelper _fWait;
        public OrderSummaryPage(IWebDriver webdriver)
        {
            this._WebDriver = webdriver;
            _fWait = new WaitHelper(webdriver);
        }

        public OrderConfirmationPage clickIConfirmmyOrder() {

            IWebElement IConfirmMyOrderButton =  _fWait.fluentWait(_ICormMyOrderXpath);

            IConfirmMyOrderButton.Click();

            return new OrderConfirmationPage(_WebDriver);
        }
    }
}
