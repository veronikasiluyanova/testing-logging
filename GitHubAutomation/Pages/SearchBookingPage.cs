using AirAsiaAutomation.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AirAsiaAutomation.Pages
{
    public class SearchBookingPage
    {
        IWebDriver driver;
        
        [FindsBy(How = How.Id, Using = "ControlGroupRetrieveBookingExpediaAKView_BookingRetrieveInputExpediaAKView_ButtonRetrieve")]
        public IWebElement searchButton;

        private By searchButtonId = By.Id("ControlGroupRetrieveBookingExpediaAKView_BookingRetrieveInputExpediaAKView_ButtonRetrieve");

        [FindsBy(How = How.XPath, Using = "//*[@id='errorSectionContent']/p")]
        public IWebElement unableToLocateBookingError;

        public SearchBookingPage (IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            Logger.Log.Info("Search booking page initialized");
        }

        public SearchBookingPage ClickSearchButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(searchButtonId));
            searchButton.Click();
            Logger.Log.Info("Search button clicked");
            return this;
        }
    }
}
