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
    internal class LoginStepDefinition : LoginPage
    {
        string itemName = "Adding item to the list";
        private static int screenshotCounter = 1; // Counter for naming screenshots

        [Given(@"User is on Sauce Labs website")]
        public void GivenUserIsOnSauceLabsWebsite()
        {
           // new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //Setup();
            //LaunchApp();
        }

        [When(@"User enters username ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenUserEntersUsernameAndPassword(string userName, string password)
        {
            Login(userName, password);
        }


        [When(@"User enters correct username ""([^""]*)"" and incorrect password ""([^""]*)""")]
        public void WhenUserEntersCorrectUsernameAndIncorrectPassword(string userName, string password)
        {
            Login(userName, password);
        }

        [Then(@"Application should display General error message")]
        public void ThenApplicationShouldDisplayGeneralErrorMessage()
        {
            try
            {
                Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", getErrorMessage());
            }
            catch (Exception e)
            {
                throw new Exception("Element is not visible!");
            }
        }

        [Then(@"Application should display product menu page")]
        public void ThenApplicationShouldDisplayProductMenuPage()
        {
            Assert.IsTrue(isUseronMenuPage());
        }


        [Then(@"Application should display error message unmatched")]
        public void ThenApplicationShouldDisplayErrorMessageUnmatched()
        {
            try
            {
                Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", getErrorMessage());
            }
            catch (Exception e)
            {
                throw new Exception("Element is not visible!");
            }
        }

        [Given(@"When User is on Sauce demo website")]
        public void GivenWhenUserAmOnSauceDemoWebsite()
        {

        }

        [Then(@"Close the application")]
        public void ThenCloseTheApplication()
        {

            // Capture a screenshot
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string screenshotPath = "D:\\Jenkins\\Results ss\\result_" + timestamp + screenshotCounter + ".png";  // Define the path to save the screenshot

            // Increment the screenshot counter
            screenshotCounter++;

            // Save the screenshot to the specified path
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);


        }

        [When(@"When User enter username and password")]
        public void WhenUserEnterUsernameAndPassword()
        {

        }

        [When(@"User click on Login button")]
        public void WhenUserClickOnLoginButton()
        {
            clickOnLoginButton();
        }

        [When(@"User is able to Login")]
        public void UserIsAbleToLogin()
        {
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url);
        }
    }
}
