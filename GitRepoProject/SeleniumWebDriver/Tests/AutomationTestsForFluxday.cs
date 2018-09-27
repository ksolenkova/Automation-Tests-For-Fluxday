using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebDriver.Models;
using SeleniumWebDriver.Pages.DashboardPage;
using SeleniumWebDriver.Pages.DepartmentsPage;
using SeleniumWebDriver.Pages.LoginPage;
using SeleniumWebDriver.Pages.UsersPage;
using System;

namespace AutomationTestsForFluxday
{
    [TestClass]
    public class AutomationTestsForFluxday
    {
        IWebDriver driver;

        [TestInitialize]
        public void TestSetup()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();

            //driver.Navigate().GoToUrl("https://app.fluxday.io/users/sign_in");
            //LogInAsAdmin();
        }

        [TestCleanup]
        public void TestTeardown()
        {
            this.driver.Quit();
        }

        [TestCategory("AdminsTests")]
        [TestMethod]
        public void Test001LogOutAsAnAdmin()
        {
            var loginPage = new LoginPage(driver);
            User userAdmin = new User("admin@fluxday.io", "password");
            var dashboardPage = new DashboardPage(driver);

            loginPage.NavigateTo();
            loginPage.LoginUser(userAdmin);

            dashboardPage.Logout.Click();

            loginPage.AssertFluxdayLogoIsDisplayed();

            //var logOut = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/ul[3]/li[2]/a"));
            //logOut.Click();

            //var logoLogin = driver.FindElement(By.ClassName("app-logo-login")).Displayed;

            //Assert.IsTrue(logoLogin);
        }

        [TestCategory("AdminsTests")]
        [TestMethod]
        public void Test002AddUserAsAnAdmin()
        {
            var usersPage = new UsersPage(driver);
            var dashboardPage = new DashboardPage(driver);

            LogInAsAdmin();

            dashboardPage.UsersLink.Click();
            usersPage.AddUser.Click();

            usersPage.NameField.SendKeys("Employee John");
            usersPage.NicknameField.SendKeys("Employee Nickname");
            usersPage.EmailField.SendKeys("employee" + GenerateNumber() + "@fluxday.io");
            usersPage.EmployeeCodeField.SendKeys("emp" + GenerateNumber());
            usersPage.PasswordField.SendKeys("password");
            usersPage.ConfirmPasswordField.SendKeys("password");
            usersPage.ManagersField.Click();
            usersPage.AdminUserOption.Click();
            usersPage.SaveButton.Click();

            usersPage.AssertNewlyCreatedUserIsDisplayed();

            DeleteCreatedUser();
            //var users = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/ul[2]/li[5]/a"));
            //users.Click();

            //Thread.Sleep(2000);
            //var addUser = driver.FindElement(By.LinkText("Add user"));
            //addUser.Click();

            //FillAddUserForm();

            //var saveButton = driver.FindElement(By.Name("commit"));
            //saveButton.Click();

            //var newUser = driver.FindElement(By.PartialLinkText("Employee John")).Displayed;

            //Assert.IsTrue(newUser);

            //DeleteCreatedUser();
        }

        [TestCategory("AdminsTests")]
        [TestMethod]
        public void Test003CreateDepartmentAsAnAdmin()
        {
            var dashboardPage = new DashboardPage(driver);
            var departmentsPage = new DepartmentsPage(driver);

            LogInAsAdmin();
            dashboardPage.DepartmentsLink.Click();
            departmentsPage.CreateDepartmentLink.Click();

            departmentsPage.TitleField.SendKeys("Administration");
            departmentsPage.CodeDepartment.SendKeys("ADM" + GenerateNumber());
            departmentsPage.Url.SendKeys("adm");
            departmentsPage.Description.SendKeys("Administration team");
            departmentsPage.ManagersDepartment.Click();
            departmentsPage.TeamLeadDepartment.Click();
            departmentsPage.SaveButton.Click();

            departmentsPage.AssertNewlyCreatedDepartmentIsDisplayed();

            DeleteDepartment();

            //var departments = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/ul[2]/li[3]/a"));
            //departments.Click();

            //Thread.Sleep(2000);
            //var createDepartment = driver.FindElement(By.LinkText("Create department"));
            //createDepartment.Click();

            //FillFormForDepartment();

            //var saveButton = driver.FindElement(By.XPath("//*[@id=\"new_project\"]/div[3]/div[2]/input"));
            //saveButton.Click();

            //var newDepartment = driver.FindElement(By.PartialLinkText("Administration")).Displayed;

            //Assert.IsTrue(newDepartment);

            //DeleteDepartment();
        }

        [TestCategory("AdminsTests")]
        [TestMethod]
        public void Test004DeleteUserAsAnAdmin()
        {
            var dashboardPage = new DashboardPage(driver);
            var usersPage = new UsersPage(driver);

            LogInAsAdmin();
            dashboardPage.UsersLink.Click();
            AddUser();

            usersPage.UserToDelete.Click();
            usersPage.SettingsIcon.Click();
            usersPage.DeleteLink.Click();

            var alert = driver.SwitchTo().Alert();
            string alertMessage = driver.SwitchTo().Alert().Text;
            alert.Accept();

            usersPage.AssertUserIsDeleted();

            //var userToDelete = driver.FindElement(By.PartialLinkText("Employee John"));
            //userToDelete.Click();

            //Thread.Sleep(1000);
            //var settings = driver.FindElement(By.XPath("//*[@id=\"pane3\"]/div/div[1]/div[2]/a/div"));
            //settings.Click();

            //var delete = driver.FindElement(By.LinkText("Delete"));
            //delete.Click();

            //IAlert alert = driver.SwitchTo().Alert();
            //string alertMessage = driver.SwitchTo().Alert().Text;
            //alert.Accept();

            //Assert.IsNotNull(userToDelete);
        }

        [TestCategory("AdminsTests")]
        [TestMethod]
        public void Test005AddNewTeamInDepartmentAsAnAdmin()
        {
            var dashboardPage = new DashboardPage(driver);
            var departmentsPage = new DepartmentsPage(driver);

            LogInAsAdmin();

            dashboardPage.DepartmentsLink.Click();
            departmentsPage.EngineeringLink.Click();
            departmentsPage.NewTeamLink.Click();

            departmentsPage.TeamNameField.SendKeys("Quality Assurance");
            departmentsPage.TeamCodeField.SendKeys("QA" + GenerateNumber());
            departmentsPage.TeamDescriptionField.SendKeys("Quality Assurance Team");
            //departmentsPage.TeamLeadsField.Click();
            //departmentsPage.TeamLeadsField.SendKeys("Team Lead");
            departmentsPage.SaveTeamButton.Click();

            departmentsPage.AssertTheNewTeamIsDisplayed();

            DeleteCreatedTeam();
            //var departments = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/ul[2]/li[3]/a"));
            //departments.Click();

            //Thread.Sleep(1000);
            //var engineering = driver.FindElement(By.XPath("//*[@id=\"pane2\"]/div[2]/a[2]/div/div[2]/div[1]"));
            //engineering.Click();

            //var newTeam = driver.FindElement(By.XPath("//*[@id=\"project-teams\"]/a"));
            //newTeam.Click();

            //FillNewTeamForm();

            //var saveButton = driver.FindElement(By.XPath("//*[@id=\"new_team\"]/div[3]/div[2]/input"));
            //saveButton.Submit();

            //var createdTeam = driver.FindElement(By.LinkText("Quality Assurance"));

            //Assert.IsTrue(createdTeam.Displayed);

            //DeleteCreatedTeam();
        }

        private void LogInAsAdmin()
        {
            var loginPage = new LoginPage(driver);
            User user = new User("admin@fluxday.io", "password");

            loginPage.NavigateTo();
            loginPage.LoginUser(user);
        }

        private void DeleteCreatedTeam()
        {
            var departmentsPage = new DepartmentsPage(driver);

            departmentsPage.Settings.Click();
            departmentsPage.DeleteTeam.Click();
            IAlert alert = driver.SwitchTo().Alert();
            string alertMessage = driver.SwitchTo().Alert().Text;
            alert.Accept();

            //var settings = driver.FindElement(By.XPath("//*[@id=\"pane3\"]/div/div[2]/div[1]/a/div"));
            //settings.Click();

            //var delete = driver.FindElement(By.XPath("//*[@id=\"drop1\"]/li[2]/a"));
            //delete.Click();
        }

        private void FillNewTeamForm()
        {
            //Thread.Sleep(1000);
            //var teamName = driver.FindElement(By.CssSelector("#team_name"));
            //teamName.SendKeys("Quality Assurance");

            //var teamCode = driver.FindElement(By.Id("team_code"));
            //teamCode.SendKeys("QA" + GenerateNumber());

            //var teamDescription = driver.FindElement(By.Id("team_description"));
            //teamDescription.SendKeys("Quality Assurance Team");

            //var teamLeads = driver.FindElement(By.XPath("//*[@id=\"s2id_autogen2\"]"));
            //teamLeads.Click();
            //teamLeads.SendKeys("Team Lead");
        }

        private void DeleteDepartment()
        {
            var departmentsPage = new DepartmentsPage(driver);

            departmentsPage.SettingsIcon.Click();
            departmentsPage.Delete.Click();
            IAlert alert = driver.SwitchTo().Alert();
            string alertMessage = driver.SwitchTo().Alert().Text;
            alert.Accept();
            //var settingsIcon = driver.FindElement(By.XPath("//*[@id=\"pane3\"]/div/div[1]/div[2]/a/div"));
            //settingsIcon.Click();

            //var delete = driver.FindElement(By.XPath("//*[@id=\"drop1\"]/li[2]/a"));
            //delete.Click();
        }

        private void FillFormForDepartment()
        {
            var title = driver.FindElement(By.Id("project_name"));
            title.SendKeys("Administration");

            var code = driver.FindElement(By.Id("project_code"));
            code.SendKeys("ADM" + GenerateNumber());

            var url = driver.FindElement(By.Id("project_website"));
            url.SendKeys("adm");

            var description = driver.FindElement(By.Id("project_description"));
            description.SendKeys("Administration team");

            var managersDepartment = driver.FindElement(By.XPath("//*[@id=\"s2id_project_user_ids\"]/ul"));
            managersDepartment.Click();

            var teamLeadDepartment = driver.FindElement(By.XPath("//*[@id=\"project_user_ids\"]/option[2]"));
            teamLeadDepartment.Click();
        }   

        //private void LogInAsAdmin()
        //{
        //    var emailField = driver.FindElement(By.Id("user_email"));
        //    emailField.SendKeys("admin@fluxday.io");

        //    var passwordField = driver.FindElement(By.Id("user_password"));
        //    passwordField.SendKeys("password");

        //    var loginButton = driver.FindElement(By.ClassName("btn-login"));
        //    loginButton.Click();
        //}

        //private void FillAddUserForm()
        //{
        //    var nameField = driver.FindElement(By.Id("user_name"));
        //    nameField.SendKeys("Employee John");

        //    var nickname = driver.FindElement(By.Id("user_nickname"));
        //    nickname.SendKeys("Employee Nickname");

        //    var email = driver.FindElement(By.Id("user_email"));
        //    email.SendKeys("employee" + GenerateNumber() + "@fluxday.io");

        //    var employeeCode = driver.FindElement(By.Id("user_employee_code"));
        //    employeeCode.SendKeys("emp" + GenerateNumber());

        //    var password = driver.FindElement(By.Id("user_password"));
        //    password.SendKeys("password");

        //    var confirmPassword = driver.FindElement(By.Id("user_password_confirmation"));
        //    confirmPassword.SendKeys("password");

        //    var managers = driver.FindElement(By.XPath("//*[@id=\"s2id_user_manager_ids\"]/ul"));
        //    managers.Click();

        //    var adminUser = driver.FindElement(By.XPath("//*[@id=\"user_manager_ids\"]/option[1]"));
        //    adminUser.Click();

        //}

        private void AddUser()
        {
            var usersPage = new UsersPage(driver);

            usersPage.AddUser.Click();
            usersPage.NameField.SendKeys("Employee John");
            usersPage.NicknameField.SendKeys("Employee Nickname");
            usersPage.EmailField.SendKeys("employee" + GenerateNumber() + "@fluxday.io");
            usersPage.EmployeeCodeField.SendKeys("emp" + GenerateNumber());
            usersPage.PasswordField.SendKeys("password");
            usersPage.ConfirmPasswordField.SendKeys("password");
            usersPage.ManagersField.Click();
            usersPage.AdminUserOption.Click();
            usersPage.SaveButton.Click();
            //var users = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/ul[2]/li[5]/a"));
            //users.Click();

            //Thread.Sleep(2000);
            //var addUser = driver.FindElement(By.XPath("//*[@id=\"pane2\"]/div[2]/a"));
            //addUser.Click();

            //FillAddUserForm();

            //var saveButton = driver.FindElement(By.Name("commit"));
            //saveButton.Click();
        }

        private void DeleteCreatedUser()
        {
            var usersPage = new UsersPage(driver);

            usersPage.UserToDelete.Click();
            usersPage.Settings.Click();
            usersPage.DeleteLink.Click();

            var alert = driver.SwitchTo().Alert();
            string alertMessage = driver.SwitchTo().Alert().Text;
            alert.Accept();
            //var userToDelete = driver.FindElement(By.PartialLinkText("Employee John"));
            //userToDelete.Click();

            //Thread.Sleep(1000);
            //var settings = driver.FindElement(By.XPath("//*[@id=\"pane3\"]/div/div[1]/div[2]/a/div"));
            //settings.Click();

            //var delete = driver.FindElement(By.LinkText("Delete"));
            //delete.Click();

            //IAlert alert = driver.SwitchTo().Alert();
            //string alertMessage = driver.SwitchTo().Alert().Text;
            //alert.Accept();
        }

        private int GenerateNumber()
        {
            DateTime dateTime = DateTime.Now;
            var millisecond = dateTime.Millisecond;
            return millisecond;
        }
    }
}


