using AutomationPracticeBDD.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeBDD.Pages
{
    public class PaymentPage
    {

        private IWebDriver _WebDriver { get; }
        private WaitHelper _fwait;
        private string _BankWireXpath = "//*[@id='HOOK_PAYMENT']/div[1]/div/p/a";
        public PaymentPage(IWebDriver webdriver)
        {
            this._WebDriver = webdriver;

            _fwait = new WaitHelper(webdriver);

        }

        public OrderSummaryPage clicktoPayWithBankWire() {

            IJavaScriptExecutor js = (IJavaScriptExecutor)_WebDriver;
            
            js.ExecuteScript(String.Format("window.scrollTo({0}, {1})", 0, 600));

            IWebElement PaybyBankWireButton = _fwait.fluentWait(_BankWireXpath);

            PaybyBankWireButton.Click();

            return new OrderSummaryPage(_WebDriver);
        }
    }
}
