using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeBDD.Helpers
{
    public class WaitHelper
    {
        public IWebDriver WebDriver { get; }

        public WaitHelper(IWebDriver webdriver)
        {
            this.WebDriver = webdriver;
        }

        public dynamic fluentWait(string xpath)
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(WebDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";

            return fluentWait.Until(x => x.FindElement(By.XPath(xpath)));

        }

        public dynamic fluentWaitPartialLink(string PartialLink)
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(WebDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";

            return fluentWait.Until(x => x.FindElement(By.PartialLinkText(PartialLink)));


        }

        public dynamic fluentWaitCssSelector(string CssSelector)
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(WebDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";

            return fluentWait.Until(x => x.FindElement(By.CssSelector(CssSelector)));

        }

        public dynamic fluentWaitLinkText(string LinkText)
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(WebDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";

            return fluentWait.Until(x => x.FindElement(By.LinkText(LinkText)));


        }

    }
}
