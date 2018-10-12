using OpenQA.Selenium;
using System;
using System.Threading;

namespace SeleniumWebDriver.Pages.DepartmentsPage
{
    public partial class DepartmentsPage : BasePage
    {
        public DepartmentsPage(IWebDriver driver) : base(driver)
        {
        }

        public void DeleteDepartment()
        {
            Thread.Sleep(1000);
            SettingsIcon.Click();
            Thread.Sleep(1000);
            Delete.Click();
            Thread.Sleep(1000);
            IAlert alert = Driver.SwitchTo().Alert();
            string alertMessage = Driver.SwitchTo().Alert().Text;
            alert.Accept();
        }

        public void DeleteCreatedTeam()
        {
            Thread.Sleep(1000);
            Settings.Click();
            Thread.Sleep(1000);
            DeleteTeam.Click();
            Thread.Sleep(1000);
            IAlert alert = Driver.SwitchTo().Alert();
            string alertMessage = Driver.SwitchTo().Alert().Text;
            alert.Accept();
        }

        public string GenerateDateTimeString()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}
