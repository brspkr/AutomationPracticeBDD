using AutomationPracticeBDD.Helpers;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutomationPracticeBDD.Hooks
{
    [Binding]
    public class Hook
    {

        private DriverHelper _helper;

        public Hook(DriverHelper helper)
        {
            this._helper = helper;
        }


        [BeforeScenario]
        public void BeforeScenario()
        {

            ChromeOptions chromeOptions = new ChromeOptions();
            //  chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("start-maximized");
            chromeOptions.AddArgument("--no-sandbox");


            _helper.Driver = new ChromeDriver(chromeOptions);
        }


        [AfterScenario]

        public void AfterScenario()
        {

            _helper.Driver.Quit();

        }
    }
}
