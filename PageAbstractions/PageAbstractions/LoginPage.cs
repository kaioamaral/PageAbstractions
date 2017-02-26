using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PageAbstractions.Enumerators;

namespace PageAbstractions
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
