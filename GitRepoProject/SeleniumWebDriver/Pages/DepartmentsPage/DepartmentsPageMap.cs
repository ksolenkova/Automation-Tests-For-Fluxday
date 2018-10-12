using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriver.Pages.DepartmentsPage
{
    public partial class DepartmentsPage
    {
        public IWebElement CreateDepartmentLink
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementExists(By.LinkText("Create department")));
                return this.Driver.FindElement(By.LinkText("Create department"));
            }
        }

        public IWebElement TitleField
        {
            get
            {
                return this.Driver.FindElement(By.Id("project_name"));
            }
        }

        public IWebElement CodeDepartment
        {
            get
            {
                return this.Driver.FindElement(By.Id("project_code"));
            }
        }

        public IWebElement Url
        {
            get
            {
                return this.Driver.FindElement(By.Id("project_website"));
            }
        }

        public IWebElement Description
        {
            get
            {
                return this.Driver.FindElement(By.Id("project_description"));
            }
        }

        public IWebElement ManagersDepartment
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"s2id_project_user_ids\"]/ul"));
            }
        }

        public IWebElement TeamLeadDepartment
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"project_user_ids\"]/option[2]"));
            }
        }

        public IWebElement SaveButton
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"new_project\"]/div[3]/div[2]/input")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"new_project\"]/div[3]/div[2]/input"));
            }
        }

        public IWebElement NewlyCreatedDepartment
        {
            get
            {
                return this.Driver.FindElement(By.PartialLinkText("Administration"));
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

        public IWebElement Delete
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"drop1\"]/li[2]/a"));
            }
        }

        public IWebElement EngineeringLink
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pane2\"]/div[2]/a[2]/div/div[2]/div[1]")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pane2\"]/div[2]/a[2]/div/div[2]/div[1]"));
            }
        }

        public IWebElement NewTeamLink
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"project-teams\"]/a")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"project-teams\"]/a"));
            }
        }

        public IWebElement TeamNameField
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementExists(By.Id("team_name")));
                return this.Driver.FindElement(By.Id("team_name"));
            }
        }

        public IWebElement TeamCodeField
        {
            get
            {
                return this.Driver.FindElement(By.Id("team_code"));
            }
        }

        public IWebElement TeamDescriptionField
        {
            get
            {
                return this.Driver.FindElement(By.Id("team_description"));
            }
        }

        public IWebElement TeamLeadsField
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"s2id_autogen2\"]"));
            }
        }

        public IWebElement SaveTeamButton
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementExists(By.Name("commit")));
                return this.Driver.FindElement(By.Name("commit"));
            }
        }

        public IWebElement CreatedTeam
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementExists(By.LinkText("Quality Assurance")));
                return this.Driver.FindElement(By.LinkText("Quality Assurance"));
            }
        }

        public IWebElement Settings
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pane3\"]/div/div[2]/div[1]/a/div")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pane3\"]/div/div[2]/div[1]/a/div"));
            }
        }

        public IWebElement DeleteTeam
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"drop1\"]/li[2]/a")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"drop1\"]/li[2]/a"));
            }
        }
    }
}
