using OpenQA.Selenium;
using SeleniumWebDriver.Models;

namespace SeleniumWebDriver.Pages.LoginPage
{
    public partial class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl("https://app.fluxday.io/users/sign_in");
        }

        public void Type(IWebElement element,string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public void LoginUser(User user)
        {
            Type(this.EmailField, user.UserEmail);
            Type(this.PasswordField, user.UserPassword);
            this.LoginButton.Click();
        }

        public void LogInAsAdmin()
        {
            User user = new User("admin@fluxday.io", "password");

            NavigateTo();
            LoginUser(user);
        }
    }
}
