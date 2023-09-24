using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Saucedemo.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;


namespace Saucedemo.Page
{
    [Binding]
    public class LoginPage: BaseClass
    {
        #region Locators
        //public static IWebDriver driver;

        //IWebElement element = driver.FindElement(By.Id("user-name"));

        By username1 = By.Id("user-name");


        By username = By.Id("user-name");
        By password = By.Id("password");
        By Btn = By.Id("login-button");
        By errorMsg = By.XPath("//div/h3");
        By dropDown = By.Id("react-burger-menu-btn");
        By logOutBtn = By.Id("logout_sidebar_link");
        By MenuHeader = By.XPath("//*[@id='header_container']/div[2]/span");


        #endregion

        public void Login()
        {
            try
            {
                SendKeys(username, Utilities.GetValue("username"));
                SendKeys(password, Utilities.GetValue("password"));
                clickOnLoginButton();
            }

            catch (Exception e)
            {
                throw new Exception("Element is not visible, Unable to Login");
            }
        }

        public void Login(string userName = null, string Password = null)
        {
            try
            {
                SendKeys(username, userName);
                SendKeys(password, Password);
                clickOnLoginButton();                
            }

            catch (Exception e)
            {
                throw new Exception("Element is not visible, Unable to Login");
            }
        }


        public void InitializeSetup()
        {
            Setup();
            LaunchApp();
            // Login();
            return;
        }
        
        public void logOut()
        {
            Click(dropDown);
            Click(logOutBtn);
        }

        public string getErrorMessage()
        {            
            return driver.FindElement(errorMsg).Text;
        }

        public void clickOnLoginButton()
        {
            Click(Btn);
        }


        public bool isUseronMenuPage()
        {
            bool isVisible = IsElementVisible(driver, MenuHeader);
            if (isVisible)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool IsElementVisible(IWebDriver driver, By elementLocator)
        {
            try
            {
                IWebElement element = driver.FindElement(elementLocator);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false; // Element not found
            }
            catch (ElementNotVisibleException)
            {
                return false; // Element found but not visible
            }
        }
    }
}
