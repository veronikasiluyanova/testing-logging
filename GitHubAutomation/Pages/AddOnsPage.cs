using AirAsiaAutomation.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AirAsiaAutomation.Pages
{
    public class AddOnsPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "addons-bottom-booking-summary-airasia-button-inner-button-booking-summary-heatmap")]
        private IWebElement continueButton;

        private By continueButtonId = By.Id("addons-bottom-booking-summary-airasia-button-inner-button-booking-summary-heatmap");

        public AddOnsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            Logger.Log.Info("Add ons page initialized");
        }

        public GuestDetailsPage ClickContinueButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(continueButtonId));
            continueButton.Click();
            Logger.Log.Info("Continue button clicked");
            return new GuestDetailsPage(driver);
        }
    }
}
