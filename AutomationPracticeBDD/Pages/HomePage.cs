using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeBDD.Pages
{
    public class HomePage 
    {
        private IWebDriver _WebDriver { get; }

        private string _SignUpXpath = "/html/body/div/div[1]/header/div[2]/div/div/nav/div[1]/a";
        public HomePage(IWebDriver webdriver)
        {
            this._WebDriver = webdriver;
        }
        public IWebElement SignInButton
        {
            get { return _WebDriver.FindElement(By.XPath("/html/body/div/div[1]/header/div[2]/div/div/nav/div[1]/a")); }
          //get { return WebDriver.FindElement(By.ClassName("login")); }

        }

        public IWebElement WomenButton
        {
            get { return _WebDriver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[6]/ul/li[1]/a")); }
            //get { return WebDriver.FindElement(By.ClassName("women")); }

        }

        public IWebElement SearchBar
        {
            get { return _WebDriver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[2]/form/input[4]")); }

        }

        public LoginPage clickSignUp() {

            var SignUpButton = _WebDriver.FindElement(By.XPath(_SignUpXpath));

            SignUpButton.Click();

            return new LoginPage(_WebDriver);
        }

    }
}
