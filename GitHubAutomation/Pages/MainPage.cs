using AirAsiaAutomation.Models;
using AirAsiaAutomation.Services;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AirAsiaAutomation.Pages
{
    public class MainPage
    {
        private static ILog Log = LogManager.GetLogger("LOGGER");
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "home-origin-autocomplete-heatmap")]
        private IWebElement departurePlaceField;

        private By departurePlaceFieldId = By.Id("home-origin-autocomplete-heatmap");

        [FindsBy(How = How.Id, Using = "home-destination-autocomplete-heatmap")]
        private IWebElement arrivalPlaceField;
        
        [FindsBy(How = How.Id, Using = "home-depart-date-heatmap")]
        public IWebElement leaveDateField;

        [FindsBy(How = How.Id, Using = "home-return-date-heatmap")]
        private IWebElement returnDateField;
        
        [FindsBy(How = How.Id, Using = "passenger")]
        private IWebElement passengerNumberListButton;

        private By passengerNumberListButtonId = By.Id("home-airasia-numeric-selector-a-home-enabled-increase-main.adult-heatmap");

        [FindsBy(How = How.Id, Using = "home-airasia-numeric-selector-a-home-enabled-increase-main.adult-heatmap")]
        public IWebElement addAdultPassengerButton;

        [FindsBy(How = How.Id, Using = "home-airasia-numeric-selector-a-home-disabled-increase-main.adult-heatmap")]
        public IWebElement addAdultPassengerButtonDisabled;

        [FindsBy(How = How.Id, Using = "home-flight-search-airasia-button-inner-button-select-flight-heatmap")]
        private IWebElement searchButton;

        private By searchButtonId = By.Id("home-flight-search-airasia-button-inner-button-select-flight-heatmap");

        [FindsBy(How = How.Id, Using = "product-tile-hotels")]
        private IWebElement hotelSelectionButton;

        private By hotelSelectionButtonId = By.Id("product-tile-hotels");

        [FindsBy(How = How.Id, Using = "product-tile-bags_meals_seats")]
        private IWebElement bagsMealsSeatsButton;

        private By bagsMealsseatsButtonId = By.Id("product-tile-bags_meals_seats");

        [FindsBy(How = How.XPath, Using = "//a[text()='Flight status']")]
        private IWebElement flightStatusButton;

        private By flightStatusButtonXPath = By.XPath("//a[text()='Flight status']");

        public MainPage(IWebDriver driver)
        {
            Logger.InitLogger();
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            Logger.Log.Info("Main page initialized");
        }

        public MainPage InputRouteData(MainPageData data)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(departurePlaceFieldId));
            departurePlaceField.Clear();
            departurePlaceField.SendKeys(data.DeparturePlace);
            arrivalPlaceField.SendKeys(data.ArrivalPlace);
            leaveDateField.Clear();
            leaveDateField.SendKeys(data.LeaveDate);
            returnDateField.Clear();
            returnDateField.SendKeys(data.ReturnDate);
            Logger.Log.Info("Route data input " + data.DeparturePlace + "/" + data.ArrivalPlace + "/" +
                data.LeaveDate + "/" + data.ReturnDate);
            return this;
        }

        public MainPage AddAdultPassenger(int countOfPassenger)
        {
            for (int i = 0; i < countOfPassenger-1; i++) 
            {
                addAdultPassengerButton.Click();
            }
            return this;
        }

        public FlightSelectPage ClickSearchButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(searchButtonId));
            searchButton.Click();
            Logger.Log.Info("Search button clicked");
            return new FlightSelectPage(driver);
        }

        public SearchHotelPage ClickHotelSelectionButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(hotelSelectionButtonId));
            hotelSelectionButton.Click();
            Logger.Log.Info("Hotel selection button clicked");
            return new SearchHotelPage(driver);
        }

        public SearchBookingPage ClickBagsMealsSeatsButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(bagsMealsseatsButtonId));
            bagsMealsSeatsButton.Click();
            Logger.Log.Info("Bag&meals&seats button clicked");
            return new SearchBookingPage(driver);
        }

        public MainPage ClickPassengerNumberListButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(passengerNumberListButtonId));
            passengerNumberListButton.Click();
            return this;
        }

        public FlightStatusPage ClickFlighStatusButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(flightStatusButtonXPath));
            flightStatusButton.Click();
            Logger.Log.Info("Flight status button clicked");
            return new FlightStatusPage(driver);
        }
    }
}
