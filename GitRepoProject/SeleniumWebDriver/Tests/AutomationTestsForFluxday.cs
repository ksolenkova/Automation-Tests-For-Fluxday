using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebDriver.Models;
using SeleniumWebDriver.Pages.DashboardPage;
using SeleniumWebDriver.Pages.DepartmentsPage;
using SeleniumWebDriver.Pages.LoginPage;
using SeleniumWebDriver.Pages.UsersPage;
using System;
using System.Threading;

namespace AutomationTestsForFluxday
{
    [TestClass]
    public class AutomationTestsForFluxday
    {
        IWebDriver driver;
        User userAdmin = new User("admin@fluxday.io", "password");
        
        [TestInitialize]
        public void TestSetup()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
            LogIn(userAdmin);
        }

        [TestCleanup]
        public void TestTeardown()
        {
            Thread.Sleep(2000);
            this.driver.Quit();
        }

        [TestCategory("AdminsTests")]
        [TestMethod]
        public void Test001LogOutAsAnAdmin()
        {
            var loginPage = new LoginPage(driver);
           
            var dashboardPage = new DashboardPage(driver);
            dashboardPage.Logout.Click();

            loginPage.AssertFluxdayLogoIsDisplayed();
        }

        [TestCategory("AdminsTests")]
        [TestMethod]
        public void Test002AddUserAsAnAdmin()
        {
            var dashboardPage = new DashboardPage(driver);
            dashboardPage.UsersLink.Click();

            var usersPage = new UsersPage(driver);
            usersPage.AddUserLink.Click();

            usersPage.NameField.SendKeys("Employee John");
            usersPage.NicknameField.SendKeys("Employee Nickname");
            usersPage.EmailField.SendKeys("employee" + usersPage.GenerateDateTimeString() + "@fluxday.io");
            usersPage.EmployeeCodeField.SendKeys("emp" + usersPage.GenerateDateTimeString());
            usersPage.PasswordField.SendKeys("password");
            usersPage.ConfirmPasswordField.SendKeys("password");
            usersPage.ManagersField.Click();
            usersPage.AdminUserOption.Click();
            usersPage.SaveButton.Click();
            Thread.Sleep(2000);

            usersPage.AssertNewlyCreatedUserIsDisplayed();

            Thread.Sleep(1000);
            usersPage.DeleteCreatedUser();
        }

        [TestCategory("AdminsTests")]
        [TestMethod]
        public void Test003CreateDepartmentAsAnAdmin()
        {
            var dashboardPage = new DashboardPage(driver);
            dashboardPage.DepartmentsLink.Click();

            var departmentsPage = new DepartmentsPage(driver);
            departmentsPage.CreateDepartmentLink.Click();

            departmentsPage.TitleField.SendKeys("Administration");
            departmentsPage.CodeDepartment.SendKeys("ADM" + departmentsPage.GenerateDateTimeString());
            departmentsPage.Url.SendKeys("adm");
            departmentsPage.Description.SendKeys("Administration team");
            departmentsPage.ManagersDepartment.Click();
            departmentsPage.TeamLeadDepartment.Click();
            departmentsPage.SaveButton.Click();
            Thread.Sleep(2000);

            departmentsPage.AssertNewlyCreatedDepartmentIsDisplayed();

            departmentsPage.DeleteDepartment();
        }

        [TestCategory("AdminsTests")]
        [TestMethod]
        public void Test004DeleteUserAsAnAdmin()
        {
            var dashboardPage = new DashboardPage(driver);
            dashboardPage.UsersLink.Click();

            var usersPage = new UsersPage(driver);
            usersPage.AddUser();
            Thread.Sleep(1000);

            usersPage.UserToDelete.Click();
            Thread.Sleep(1000);
            usersPage.SettingsIcon.Click();
            Thread.Sleep(1000);
            usersPage.DeleteLink.Click();

            var alert = driver.SwitchTo().Alert();
            string alertMessage = driver.SwitchTo().Alert().Text;
            alert.Accept();

            usersPage.AssertUserIsDeleted();
        }

        [TestCategory("AdminsTests")]
        [TestMethod]
        public void Test005AddNewTeamInDepartmentAsAnAdmin()
        {
            var dashboardPage = new DashboardPage(driver);
            dashboardPage.DepartmentsLink.Click();

            var departmentsPage = new DepartmentsPage(driver);
            departmentsPage.EngineeringLink.Click();
            departmentsPage.NewTeamLink.Click();

            departmentsPage.TeamNameField.SendKeys("Quality Assurance");
            departmentsPage.TeamCodeField.SendKeys("QA" + departmentsPage.GenerateDateTimeString());
            departmentsPage.TeamDescriptionField.SendKeys("Quality Assurance Team");
            departmentsPage.SaveTeamButton.Click();
            Thread.Sleep(5000);

            departmentsPage.AssertTheNewTeamIsDisplayed();

            departmentsPage.DeleteCreatedTeam();
        }

        private void LogIn(User user)
        {
            var loginPage = new LoginPage(driver);

            loginPage.NavigateTo();
            loginPage.LoginUser(user);
        }
    }
}


