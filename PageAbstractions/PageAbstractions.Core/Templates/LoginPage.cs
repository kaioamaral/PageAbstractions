using OpenQA.Selenium;
using PageAbstractions.Core.Enumerators;
using System;

namespace PageAbstractions.Core.Templates
{
    public class LoginPage : Page
    {
        public LoginPage(IWebDriver driver, TimeSpan defaultTimeSpan, string pageUrl) : base(driver, defaultTimeSpan)
        {
            base.NavigateTo(pageUrl);
        }
        
        public LoginPage FillUsername(string username, string targetElement, Locator locator)
        {
            base.Fill(targetElement, username, locator);
            return this;
        }

        public LoginPage FillPassword(string password, string targetElement, Locator locator)
        {
            base.Fill(targetElement, password, locator);
            return this;
        }

        public void Login(string targetElement, Locator locator)
        {
            base.Click(targetElement, locator);
        }
    }
}
