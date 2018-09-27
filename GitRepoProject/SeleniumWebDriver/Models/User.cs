namespace SeleniumWebDriver.Models
{
    public class User
    {
        private string userEmail;
        private string userPassword;

        public User(string userEmail, string userPassword)
        {
            this.userEmail = userEmail;
            this.userPassword = userPassword;
        }

        public string UserEmail
        {
            get { return this.userEmail; }
            set { this.userEmail = value;}
        }

        public string UserPassword
        {
            get { return this.userPassword; }
            set { this.userPassword = value; }
        }
    }
}
