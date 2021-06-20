using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeBDD.Pages
{
    public class LoginPage 
    {

        private IWebDriver _WebDriver { get; }

        public LoginPage(IWebDriver webdriver)
        {
            this._WebDriver = webdriver;
        }

        public LoginPage enterUsername(string username)
        {

            var usernameField = _WebDriver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[2]/form/div/div[1]/input"));

            usernameField.Click();

            usernameField.SendKeys(username);

            return this;
        }

        public LoginPage enterPassword(string password)
        {

            var passwordField = _WebDriver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[2]/form/div/div[2]/span/input"));

            passwordField.Click();

            passwordField.SendKeys(password);

            return this;
        }

        public MyAccountPage clickSignIn()
            
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)_WebDriver;

            js.ExecuteScript(String.Format("window.scrollTo({0}, {1})", 0, 120));


            var signInButton = _WebDriver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[2]/form/div/p[2]/button"));

            signInButton.Click();

            return new MyAccountPage(_WebDriver);

        }



    }
}
