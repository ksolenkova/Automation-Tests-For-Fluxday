using OpenQA.Selenium;
using System;
using System.Threading;

namespace SeleniumWebDriver.Pages.UsersPage
{
    public partial class UsersPage : BasePage
    {
        public UsersPage(IWebDriver driver) : base(driver)
        {
        }

        public void AddUser()
        {
            AddUserLink.Click();
            NameField.SendKeys("Employee John");
            NicknameField.SendKeys("Employee Nickname");
            EmailField.SendKeys("employee" + GenerateDateTimeString() + "@fluxday.io");
            EmployeeCodeField.SendKeys("emp" + GenerateDateTimeString());
            PasswordField.SendKeys("password");
            ConfirmPasswordField.SendKeys("password");
            ManagersField.Click();
            AdminUserOption.Click();
            SaveButton.Click();
            Thread.Sleep(1000);
        }

        public void DeleteCreatedUser()
        {
            UserToDelete.Click();
            Thread.Sleep(1000);
            Settings.Click();
            Thread.Sleep(1000);
            DeleteLink.Click();
            Thread.Sleep(1000);

            var alert = Driver.SwitchTo().Alert();
            string alertMessage = Driver.SwitchTo().Alert().Text;
            alert.Accept();
        }

        public string GenerateDateTimeString()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}
