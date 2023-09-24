using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Saucedemo.Page;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using WebDriverManager.DriverConfigs.Impl;

namespace Saucedemo.StepDefinitions
{
    [Binding]
    internal class ProductPageStepDefintion : ProductPage
    {
        private LoginPage loginPage;

        [Given(@"Given User is on Sauce Labs website")]
        public void GivenGivenUserIsOnSauceLabsWebsite()
        {
            throw new PendingStepException();
        }


      

        [When(@"User applies sorting of price high to low")]
        public void WhenUserAppliesSortingOfPriceHighToLow()
        {
            ApplysortpriceHtoL();

        }

        [Then(@"Sorting should be applied")]
        public void ThenSortingShouldBeApplied()
        {
            checksortHtoL();
        }


    }
}
