using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeBDD.Pages
{

    //This class holds common elements through pages, such as search bar...
   public class BasePage
    {
        private IWebDriver _WebDriver { get; }
        private string _SearchBarXpath = "/html/body/div/div[1]/header/div[3]/div/div/div[2]/form/input[4]";
        private string _SearchButtonXpath = "/html/body/div/div[1]/header/div[3]/div/div/div[2]/form/button";
        private string _CartButtonXpath = "//*[@id='header']/div[3]/div/div/div[3]/div/a";
        public BasePage(IWebDriver webdriver)
        {
            this._WebDriver = webdriver;
        }

        public SearchResultPage searchProduct(string product)
        {
            IWebElement SearchBar = _WebDriver.FindElement(By.XPath(_SearchBarXpath));

            IWebElement SearchButton = _WebDriver.FindElement(By.XPath(_SearchButtonXpath));

            SearchBar.Click();

            SearchBar.Clear();

            SearchBar.SendKeys(product);

            SearchButton.Click();

            return new SearchResultPage(_WebDriver);
        }

        public CartPage clicktoCart() {

            IWebElement Cart = _WebDriver.FindElement(By.XPath(_CartButtonXpath));

            Cart.Click();

            return new CartPage(_WebDriver);
        }
    }
}
