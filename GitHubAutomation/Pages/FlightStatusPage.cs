using AirAsiaAutomation.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AirAsiaAutomation.Pages
{
    public class FlightStatusPage
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id=flightNumber]")]
        private IWebElement flightNumberField;

        private By flightNumberFieldId = By.XPath("//*[@id=flightNumber]");

        [FindsBy(How = How.XPath, Using = "//aa-flight-number-search/div/button[text()='Find flights']")]
        private IWebElement searchButton;

        private By searchButtonXPath = By.XPath("//aa-flight-number-search/div/button[text()='Find flights']");

        [FindsBy(How = How.XPath, Using = "//p[@class='p-cls-Error']")]
        public IWebElement incorrectFormatOfNumberError;

        public FlightStatusPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            Logger.Log.Info("Flight status page initialized");
        }

        public FlightStatusPage InputFlightNumber(string number)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(flightNumberFieldId));
            flightNumberField.SendKeys(number);
            Logger.Log.Info("Flight number input - " + number);
            return this;
        }

        public FlightStatusPage ClickSearchButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(searchButtonXPath));
            searchButton.Click();
            Logger.Log.Info("Search button clicked");
            return this;
        }
    }
}
