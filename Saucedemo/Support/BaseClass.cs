using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using Newtonsoft.Json;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Interactions;


namespace Saucedemo.Support
{
    public class BaseClass
    {
        public static IWebDriver driver;
        //       protected const int Timeout = 160; // meant to be seconds

        //WebDriverWait Wait= new(driver, TimeSpan.FromSeconds(120));
        //WebDriverWait Wait5Sec = new(driver, TimeSpan.FromSeconds(5));
        //private Actions actions;

        //        Wait = new (driver, TimeSpan.FromSeconds(Timeout));
        //        Wait5Sec = new (driver, TimeSpan.FromSeconds(5));

        public IWebDriver InitializeDriver(string browserName)
        {
            var chromeOptions = new ChromeOptions();
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver(chromeOptions);

            /*switch (browserName.ToLower())
            {
                case "firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    return new FirefoxDriver();

                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("Headless");
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    return new ChromeDriver(chromeOptions);

                case "edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    return new EdgeDriver();

                default: throw new ArgumentOutOfRangeException("NULL");

            }*/

        }


        public void Setup()
        {
            driver = InitializeDriver(Utilities.GetValue("browserName"));
            driver.Manage().Window.Maximize();
        }

        public void LaunchApp()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        public void CloseDriver()
        {
            driver.Close();
        }

        internal void SendKeys(By element, string value)
        {
            driver.FindElement(element).SendKeys(value);
        }
        internal void Click(By element)
        {
            driver.FindElement(element).Click();

        }


        internal void WaitForElementToBeClickable(By webElement)
        {
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
        }

    }
}
