using AirAsiaAutomation.Driver;
using AirAsiaAutomation.Services;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;

namespace AirAsiaAutomation.Tests
{
    public class TestConfig
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void TestStart()
        {
            Driver = DriverSingleton.GetDriver();
            Logger.InitLogger();
            Logger.Log.Info("Browser initialized");
        }

        [TearDown]
        public void TestFinish()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\Screenshots";
                Directory.CreateDirectory(screenFolder);
                Screenshot screen = Driver.TakeScreenshot();
                screen.SaveAsFile(screenFolder + @"\Screenshot" + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                    ScreenshotImageFormat.Png);
                Logger.Log.Error(TestContext.CurrentContext.Result.Message);
            }
            DriverSingleton.CloseDriver();
        }
    }
}
