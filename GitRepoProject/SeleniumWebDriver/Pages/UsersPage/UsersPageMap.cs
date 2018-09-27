using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriver.Pages.UsersPage
{
    public partial class UsersPage
    {
        public IWebElement AddUser
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pane2\"]/div[2]/a")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pane2\"]/div[2]/a"));
            }
        }

        public IWebElement NameField
        {
            get
            {
                return this.Driver.FindElement(By.Id("user_name"));
            }
        }

        public IWebElement NicknameField
        {
            get
            {
                return this.Driver.FindElement(By.Id("user_nickname"));
            }
        }

        public IWebElement EmailField
        {
            get
            {
                return this.Driver.FindElement(By.Id("user_email"));
            }
        }

        public IWebElement EmployeeCodeField
        {
            get
            {
                return this.Driver.FindElement(By.Id("user_employee_code"));
            }
        }

        public IWebElement PasswordField
        {
            get
            {
                return this.Driver.FindElement(By.Id("user_password"));
            }
        }

        public IWebElement ConfirmPasswordField
        {
            get
            {
                return this.Driver.FindElement(By.Id("user_password_confirmation"));
            }
        }

        public IWebElement ManagersField
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"s2id_user_manager_ids\"]/ul"));
            }
        }

        public IWebElement AdminUserOption
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"user_manager_ids\"]/option[1]"));
            }
        }

        public IWebElement SaveButton
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementExists(By.Name("commit")));
                return this.Driver.FindElement(By.Name("commit"));
            }
        }

        public IWebElement NewCreatedUser
        {
            get
            {
                return this.Driver.FindElement(By.PartialLinkText("Employee John"));
            }
        }

        public IWebElement UserToDelete
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pane2\"]/div[2]/div[4]/div/div[2]/a[1]")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pane2\"]/div[2]/div[4]/div/div[2]/a[1]"));
            }
        }

        public IWebElement SettingsIcon
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pane3\"]/div/div[1]/div[2]/a/div")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pane3\"]/div/div[1]/div[2]/a/div"));
            }
        }

        public IWebElement Settings
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"pane3\"]/div/div[1]/div[2]/a/div"));
            }
        }

        public IWebElement DeleteLink
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"drop1\"]/li[2]/a")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"drop1\"]/li[2]/a"));
            }
        }

        public IWebElement Delete
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementExists(By.LinkText("Delete")));
                return this.Driver.FindElement(By.LinkText("Delete"));
            }
        }
    }
}
