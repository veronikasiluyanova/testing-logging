using AirAsiaAutomation.Models;
using AirAsiaAutomation.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AirAsiaAutomation.Pages
{
    public class SearchHotelPage
    {
        IWebDriver driver;
    
        [FindsBy(How = How.XPath, Using = "//a[@data-lob='hotelOnly']")]
        private IWebElement hotelOnlyButton;

        private By hotelOnlyButtonXPath = By.XPath("//a[@data-lob='hotelOnly']");

        [FindsBy(How = How.Id, Using = "H-destination")]
        private IWebElement destinationField;

        [FindsBy(How = How.Id, Using = "H-fromDate")]
        private IWebElement checkInDateField;

        [FindsBy(How = How.Id, Using = "H-toDate")]
        private IWebElement checkOutDateField;

        [FindsBy(How = How.Id, Using = "H-searchButtonExt1")]
        private IWebElement hotelSearchButton;

        private By searchButtonId = By.Id("H-searchButtonExt1");

        [FindsBy(How = How.XPath, Using = "//a[@class='error-link']")]
        public IWebElement incorrectDateError;
        
        public SearchHotelPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            Logger.Log.Info("Search hotel page initialized");
        }

        public SearchHotelPage InputBookingData(SearchHotelPageData data)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(hotelOnlyButtonXPath));
            hotelOnlyButton.Click();
            destinationField.Clear();
            destinationField.SendKeys(data.Destination);
            checkInDateField.SendKeys(data.CheckInDate);
            checkOutDateField.SendKeys(data.CheckOutDate);
            Logger.Log.Info("Booking data input " + data.Destination + "/" + data.CheckInDate + "/" + data.CheckOutDate);
            return this;
        }

        public SearchHotelPage ClickHotelSearchButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(searchButtonId));
            hotelSearchButton.Click();
            Logger.Log.Info("Search button clicked");
            return this;
        }
    }
}
