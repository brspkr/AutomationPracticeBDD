using AutomationPracticeBDD.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeBDD.Pages
{
    public class AddressPage
    {

        private IWebDriver _WebDriver { get; }
        private WaitHelper _fwait;
        private string _DeliveryAddressXpath = "/html/body/div/div[2]/div/div[3]/div/form/div/div[2]/div[1]/ul/li[2]";
        private string _ProceedtoCheckoutXpath = "//*[@id='center_column']/form/p/button/span";

        public AddressPage(IWebDriver webdriver)
        {
            this._WebDriver = webdriver;

            _fwait = new WaitHelper(_WebDriver);

        }

        public ShippingPage clickProceedtoCheckout() {


            _fwait.fluentWait(_DeliveryAddressXpath);

            IJavaScriptExecutor js = (IJavaScriptExecutor)_WebDriver; js.ExecuteScript(String.Format("window.scrollTo({0}, {1})", 0, 600));

            IWebElement ProceedtoCheckoutButton = _fwait.fluentWait(_ProceedtoCheckoutXpath);

            ProceedtoCheckoutButton.Click();


            return new ShippingPage(_WebDriver);
        }
    }
}
