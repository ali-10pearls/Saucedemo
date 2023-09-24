using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Saucedemo.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucedemo.Page
{
    public class ProductPage : BaseClass
    {
        #region Locators

        By product = By.XPath("//div[@class='inventory_item'][]");
       // By sortoption = By.XPath("//*[@id=\"header_container\"]/div[2]/div/span/select");
        By dropdownLocator = By.CssSelector("select.product_sort_container");
        By priceLocator = By.CssSelector("div.inventory_item_price");

        #endregion


        public void addItemToCart(int items)
        {
            driver.FindElement(product).Click();
            // //div[@class='inventory_item_name' and contains(text(),'Sauce Labs Fleece')] adding jacket

            //div//div[@class='inventory_item_name' and contains(text(),'Bolt T-Shirt')]
        }

        public void ApplysortpriceHtoL() 
        {
           // driver.FindElement(sortoption).Click();
            IWebElement dropdown = driver.FindElement(dropdownLocator);
            SelectElement select = new SelectElement(dropdown);
            select.SelectByIndex(3);
        }

        public bool CompareElementValue(IWebDriver driver, By elementLocator, string expectedValue)
        {
            try
            {
                IWebElement element = driver.FindElement(elementLocator);
                string actualValue = element.Text.Trim();
                return actualValue.Equals(expectedValue);
            }
            catch (NoSuchElementException)
            {
                // Element not found
                return false;
            }
        }

        public void checksortHtoL()
        {
            IWebDriver driver = new ChromeDriver();
            string expectedValue = "$49.99";

            bool isEqual = CompareElementValue(driver, priceLocator, expectedValue);

            if (isEqual)
            {
                Console.WriteLine("The element value matches the expected value.");
            }
            else
            {
                Console.WriteLine("The element value does not match the expected value.");
            }
        }

    }
}
