using AirAsiaAutomation.Models;
using AirAsiaAutomation.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AirAsiaAutomation.Pages
{
    public class GuestDetailsPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[text()='Guest Details']")]
        public IWebElement header;

        [FindsBy(How = How.Id, Using = "adult-0-given-name-heatmap-autocomplete-heatmap")]
        private IWebElement givenNameField;

        private By givenNameFieldId = By.Id("adult-0-given-name-heatmap-autocomplete-heatmap");

        [FindsBy(How = How.Id, Using = "adult-0-sur-name-heatmap")]
        private IWebElement surnameField;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement emailField;

        [FindsBy(How = How.Id, Using = "contact-mobile-number")]
        private IWebElement mobilePhoneField;

        [FindsBy(How = How.XPath, Using = "//airasia-input-validation/div")]
        public IWebElement incorrectNameError;

        public GuestDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            Logger.Log.Info("Guest details page initialized");
        }

        public GuestDetailsPage InputGuestData(GuestDetailsPageData data)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(givenNameFieldId));
            givenNameField.SendKeys(data.GivenName);
            surnameField.SendKeys(data.Surname);
            emailField.SendKeys(data.Email);
            Logger.Log.Info("Guest data input " + data.GivenName + "/" + data.Surname + "/" + data.Email);
            return this;
        }
    }
}
