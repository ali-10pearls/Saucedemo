using Saucedemo.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Saucedemo.Support
{
    [Binding]
    public sealed class Hooks : LoginPage
    {
        private ExtentReports extent;
        private ExtentTest test;


        [BeforeScenario]


        public void BeforeScenario()
        {
            var htmlReporter = new ExtentHtmlReporter(@"D:\ReportsbyAli\Report.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            InitializeSetup();
            test = extent.CreateTest("sample reporting");
        }

        [BeforeScenario("@NegativeCase")]
        public void BeforeScenarioWithTag()
        {
            logOut();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            extent.Flush();
            CloseDriver();
        }
    }
}
