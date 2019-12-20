using AirAsiaAutomation.Models;
using AirAsiaAutomation.Pages;
using AirAsiaAutomation.Services;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AirAsiaAutomation.Tests
{
    public class AirAsiaTests : TestConfig
    {
        private const string URL = "https://www.airasia.com/en/gb";

        private const string IncorrectDateError = "The check-out date must occur after the check-in date. Please change the date.";
        private const string ExpectedHeaderText = "Guest Details";
        private const string UnableToLocateBookingError = "We're unable to locate your flight booking. You can only search for bookings made with AirAsia or other online travel websites.";
        private const string IncorrectGuestNameError = "Your name must be as stated on your ID or passport in English alphabets (A to Z) only. Special characters or symbols are not allowed.";
        private const string IncorrectFlightNumberError = "Search by route aaaa error Flight number must start with a valid airline code. Example: AK, FD, I5";

        private const string TestDate = "05/12/2019";
        private const string TestFlightNumber = "AAA";
        private const int TestAdultPassengerNumber = 9;
        

        [Test]
        public void HotelCheckInDateLaterThanCheckOutDateTest()
        {
            Logger.InitLogger();
            SearchHotelPageData searchHotelPageData = new SearchHotelPageData(SearchHotelPageDataReader.GetData("Destination"), 
                SearchHotelPageDataReader.GetData("CheckInDate"), SearchHotelPageDataReader.GetData("CheckOutDate"));

            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            SearchHotelPage page = new MainPage(Driver)
                     .ClickHotelSelectionButton()
                     .InputBookingData(searchHotelPageData)
                     .ClickHotelSearchButton();
            Assert.AreEqual(IncorrectDateError, page.incorrectDateError.Text);
            Logger.Log.Info("Test complete successfully");
        }


        [Test]
        public void FlightBookingTest()
        {
            Logger.InitLogger();
            MainPageData mainPageData = new MainPageData(MainPageDataReader.GetData("DeparturePlace"),
                MainPageDataReader.GetData("ArrivalPlace"), MainPageDataReader.GetData("LeaveDate"),
                MainPageDataReader.GetData("ReturnDate"));

            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            GuestDetailsPage page = new MainPage(Driver)
                     .InputRouteData(mainPageData)
                     .ClickSearchButton()
                     .ClickContinueButton()
                     .ClickContinueButton();
            Assert.AreEqual(ExpectedHeaderText, page.header.Text);
            Logger.Log.Info("Test complete successfully");
        }

        [Test]
        public void NoBookingInformationTest()
        {
            Logger.InitLogger();
            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            SearchBookingPage page = new MainPage(Driver)
                .ClickBagsMealsSeatsButton()
                .ClickSearchButton();
            Assert.AreEqual(UnableToLocateBookingError, page.unableToLocateBookingError.Text);
            Logger.Log.Info("Test complete successfully");
        }

        [Test]
        public void TooManyPassengersTest()
        {
            Logger.InitLogger();
            MainPageData mainPageData = new MainPageData(MainPageDataReader.GetData("DeparturePlace"),
                   MainPageDataReader.GetData("ArrivalPlace"), MainPageDataReader.GetData("LeaveDate"),
                   MainPageDataReader.GetData("ReturnDate"));

            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            MainPage page = new MainPage(Driver)
                .InputRouteData(mainPageData)
                .ClickPassengerNumberListButton()
                .AddAdultPassenger(TestAdultPassengerNumber);
            Assert.IsTrue(page.addAdultPassengerButtonDisabled.Displayed);
            Logger.Log.Info("Test complete successfully");
        }

        [Test]
        public void EmptyArrivalFieldTest()
        {
            Logger.InitLogger();
            MainPageData mainPageData = new MainPageData(MainPageDataReader.GetData("DeparturePlace"),
                string.Empty, MainPageDataReader.GetData("LeaveDate"),
                MainPageDataReader.GetData("ReturnDate"));

            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            FlightSelectPage page = new MainPage(Driver)
                    .InputRouteData(mainPageData)
                    .ClickSearchButton();
            Assert.IsTrue(Driver.FindElement(By.TagName("em")).Displayed);
            Logger.Log.Info("Test complete successfully");
        }

        [Test]
        public void EmptyDepartureFieldTest()
        {
            Logger.InitLogger();
            MainPageData mainPageData = new MainPageData(string.Empty, MainPageDataReader.GetData("ArrivalPlace"), 
                MainPageDataReader.GetData("LeaveDate"),
                MainPageDataReader.GetData("ReturnDate"));

            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            FlightSelectPage page = new MainPage(Driver)
                    .InputRouteData(mainPageData)
                    .ClickSearchButton();
            Assert.IsTrue(Driver.FindElement(By.TagName("em")).Displayed);
            Logger.Log.Info("Test complete successfully");
        }

        [Test]
        public void SameDepartureandArrivalPlacesTest()
        {
            Logger.InitLogger();
            MainPageData mainPageData = new MainPageData(MainPageDataReader.GetData("DeparturePlace"),
                MainPageDataReader.GetData("DeparturePlace"), MainPageDataReader.GetData("LeaveDate"),
                MainPageDataReader.GetData("ReturnDate"));

            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            FlightSelectPage page = new MainPage(Driver)
                    .InputRouteData(mainPageData)
                    .ClickSearchButton();
            Assert.IsTrue(Driver.FindElement(By.TagName("em")).Displayed);
            Logger.Log.Info("Test complete successfully");
        }

        [Test]
        public void IncorrectFormatOfGuestNameTest()
        {
            Logger.InitLogger();
            MainPageData mainPageData = new MainPageData(MainPageDataReader.GetData("DeparturePlace"),
                MainPageDataReader.GetData("ArrivalPlace"), MainPageDataReader.GetData("LeaveDate"),
                MainPageDataReader.GetData("ReturnDate"));

            GuestDetailsPageData guestDetailsPageData = new GuestDetailsPageData(GuestDetailsPageDataReader.GetData("GivenName"),
                GuestDetailsPageDataReader.GetData("Surname"), GuestDetailsPageDataReader.GetData("Email"));

            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            GuestDetailsPage page = new MainPage(Driver)
                     .InputRouteData(mainPageData)
                     .ClickSearchButton()
                     .ClickContinueButton()
                     .ClickContinueButton()
                     .InputGuestData(guestDetailsPageData);
            Assert.AreEqual(IncorrectGuestNameError, page.incorrectNameError.Text);
            Logger.Log.Info("Test complete successfully");
        }

        [Test]
        public void IncorrectFormatOfBookingNumberTest()
        {
            Logger.InitLogger();
            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            FlightStatusPage page = new MainPage(Driver)
                .ClickFlighStatusButton()
                .InputFlightNumber(TestFlightNumber)
                .ClickSearchButton();
            Assert.AreEqual(IncorrectFlightNumberError, page.incorrectFormatOfNumberError.Text);
            Logger.Log.Info("Test complete successfully");
        }

        [Test]
        public void BookingDayEarlierThanCurrentTest()
        {
            Logger.InitLogger();
            MainPageData mainPageData = new MainPageData(MainPageDataReader.GetData("DeparturePlace"),
                MainPageDataReader.GetData("ArrivalPlace"), TestDate,
                MainPageDataReader.GetData("ReturnDate"));

            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            MainPage page = new MainPage(Driver)
                     .InputRouteData(mainPageData);
            Assert.AreNotEqual(page.leaveDateField.Text, TestDate);
            Logger.Log.Info("Test complete successfully");
        }
    }
}
