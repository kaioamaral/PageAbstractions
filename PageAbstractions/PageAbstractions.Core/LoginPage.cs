using OpenQA.Selenium;
using PageAbstractions.Core.Abstractions;
using PageAbstractions.Core.Enumerators;
using System;

namespace PageAbstractions.Core
{
    public class LoginPage : Page
    {
        public LoginPage(IWebDriver driver, TimeSpan defaultTimeSpan, string pageUrl)
            : base(driver, defaultTimeSpan)
        {
            base.NavigateTo(pageUrl);
        }

        public LoginPage FillUsername(string targetElement, Locator locator)
        {
            base.Fill(targetElement, Faker.NameFaker.FirstName(), locator);
            return this;
        }

        public LoginPage FillUsername(string username, string targetElement, Locator locator)
        {
            base.Fill(targetElement, username, locator);
            return this;
        }

        public LoginPage FillEmail(string targetElement, Locator locator)
        {
            base.Fill(targetElement, Faker.InternetFaker.Email(), locator);
            return this;
        }

        public LoginPage FillEmail(string email, string targetElement, Locator locator)
        {
            this.Fill(targetElement, email, locator);
            return this;
        }

        public LoginPage FillPassword(string targetElement, Locator locator)
        {
            base.Fill(targetElement, string.Format("A!1234{0}", Faker.NameFaker.FirstName()), locator);
            return this;
        }

        public LoginPage FillPassword(string password, string targetElement, Locator locator)
        {
            base.Fill(targetElement, password, locator);
            return this;
        }

        public void SubmitByClickingIn(string targetElement, Locator locator)
        {
            base.Click(targetElement, locator);
        }
    }
}
