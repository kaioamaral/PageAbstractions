using OpenQA.Selenium;
using PageAbstractions.Core.Enumerators;
using System;

namespace PageAbstractions.Core.Templates
{
    public class RegisterPage : Page
    {
        private string password;

        public RegisterPage(string pageUrl, IWebDriver driver, TimeSpan defaultTimeSpan)
            : base(driver, defaultTimeSpan)
        {
            base.NavigateTo(pageUrl);
            this.password = Faker.StringFaker.Alpha(12);
        }

        public RegisterPage FillEmail(string element, Locator locator)
        {
            base.Fill(element, Faker.InternetFaker.Email(), locator);
            return this;
        }

        public RegisterPage FillEmail(string element, string email, Locator locator)
        {
            base.Fill(element, email, locator);
            return this;
        }

        public RegisterPage FillUsername(string element, Locator locator)
        {
            base.Fill(element, Faker.NameFaker.FirstName(), locator);
            return this;
        }

        public RegisterPage FillUsername(string element, string username, Locator locator)
        {
            base.Fill(element, username, locator);
            return this;
        }
        
        public RegisterPage FillPassword(string targetElement, Locator locator)
        {
            base.Fill(targetElement, this.password, locator);
            return this;
        }

        public RegisterPage FillPassword(string targetElement, string password, Locator locator)
        {
            base.Fill(targetElement, password, locator);
            this.password = password;
            return this;
        }
        
        public RegisterPage ConfirmPassword(string targetElement, Locator locator)
        {
            base.Fill(targetElement, this.password, locator);
            return this;
        }

        public void Done(string targetButton, Locator locator)
        {
            base.Click(targetButton, locator);
        }
    }
}
