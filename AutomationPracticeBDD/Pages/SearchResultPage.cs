using AutomationPracticeBDD.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomationPracticeBDD.Pages
{
    public class SearchResultPage
    {

        private IWebDriver _WebDriver { get; }
        private WaitHelper fwait;
        private string _ItemXpath = "//*[@id='center_column']/ul/li/div/div[1]";
        //private string _MoreXpath = "//*[@id='center_column']/ul/li/div/div[2]/div[2]/a[2]/span";
        //private string _MoreCSS = "#center_column > ul > li > div > div.right-block > div.button-container > a.button.lnk_view.btn.btn-default";
        //private string _CSSSelector = "#center_column > ul > li > div > div.left-block > div > a.product_img_link";

        public SearchResultPage(IWebDriver webdriver)
        {
            this._WebDriver = webdriver;
            fwait = new WaitHelper(_WebDriver);

        }


        public ItemDetails clicktoItem()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)_WebDriver;

            js.ExecuteScript(String.Format("window.scrollTo({0}, {1})", 0, 400));

            IWebElement Item = fwait.fluentWait(_ItemXpath);

            Actions a = new Actions(_WebDriver);

            a.MoveToElement(Item, 15, 15).Click().Perform();

            return new ItemDetails(_WebDriver);


        }

    }
}