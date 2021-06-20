using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeBDD.Pages
{
    public class MyAccountPage 
    {

        private IWebDriver _WebDriver { get; }
        public MyAccountPage(IWebDriver webdriver)
        {
            this._WebDriver = webdriver;
        }

    }
}
