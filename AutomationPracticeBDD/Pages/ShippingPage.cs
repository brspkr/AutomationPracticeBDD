using AutomationPracticeBDD.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeBDD.Pages
{
    public class ShippingPage
    {
        private IWebDriver _WebDriver { get; }
        private string _AgreetoTermsXpath = "//*[@id='form']/div/p[2]/label";
        private string _ProceedtoCheckoutXpath = "//*[@id='form']/p/button/span";
        private WaitHelper _fwait;


        public ShippingPage(IWebDriver webdriver)
        {
            this._WebDriver = webdriver;
            _fwait = new WaitHelper(webdriver);
        }

        public ShippingPage clickAgreetoTerms() {

            IJavaScriptExecutor js = (IJavaScriptExecutor)_WebDriver;
            
            js.ExecuteScript(String.Format("window.scrollTo({0}, {1})", 0, 120));

            IWebElement AgreetoTermsCheckbox = _fwait.fluentWait(_AgreetoTermsXpath);

            AgreetoTermsCheckbox.Click();

            return this;
        }
        public PaymentPage clickProceedtoCheckout()
        {

            IWebElement ProceedtoCheckoutButton = _fwait.fluentWait(_ProceedtoCheckoutXpath);

            ProceedtoCheckoutButton.Click();

            return new PaymentPage(_WebDriver);
        }



    }
}
