using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace AutomationTestsForFluxday
{
    [TestClass]
    public class AutomationTestsForFluxday
    {
        IWebDriver driver;

        [TestInitialize]
        public void TestSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://app.fluxday.io/users/sign_in");
        }

        [TestCleanup]
        public void TestTeardown()
        {
            driver.Quit();
        }

        [TestCategory("AdminsTests")]
        [TestMethod]
        public void Test001LogInAsAnAdmin()
        {
            IWebElement emailField = driver.FindElement(By.Id("user_email"));
            emailField.SendKeys("admin@fluxday.io");

            IWebElement passwordField = driver.FindElement(By.Id("user_password"));
            passwordField.SendKeys("password");

            IWebElement loginButton = driver.FindElement(By.ClassName("btn-login"));
            loginButton.Click();

            var fadeOutMessage = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div")).Text;

            Assert.IsTrue(fadeOutMessage.Contains("Signed in successfully."));
        }

        [TestCategory("AdminsTests")]
        [TestMethod]
        public void Test002LogOutAsAnAdmin()
        {

        }   

        [TestCategory("AdminsTests")]
        [TestMethod]
        public void Test003AddUserAsAnAdmin()
        {

        }

        [TestCategory("AdminsTests")]
        [TestMethod]
        public void Test004DeleteUserAsAnAdmin()
        {

        }

        [TestCategory("AdminsTests")]
        [TestMethod]
        public void Test005CreateDepartmentAsAnAdmin()
        {

        }

        [TestCategory("AdminsTests")]
        [TestMethod]
        public void Test006AddNewTeamInDepartmentAsAnAdmin()
        {

        }
    }
}
