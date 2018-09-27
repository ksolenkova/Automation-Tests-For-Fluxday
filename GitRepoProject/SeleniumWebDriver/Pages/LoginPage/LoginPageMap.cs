using OpenQA.Selenium;

namespace SeleniumWebDriver.Pages.LoginPage
{
    public partial class LoginPage
    {
        public IWebElement EmailField
        {
            get
            {
                return this.Driver.FindElement(By.Id("user_email"));
            }
        }

        public IWebElement PasswordField
        {
            get
            {
                return this.Driver.FindElement(By.Id("user_password"));
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("btn-login"));
            }
        }

        public IWebElement LogoLogin
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("app-logo-login"));
            }
        }
    }
}
