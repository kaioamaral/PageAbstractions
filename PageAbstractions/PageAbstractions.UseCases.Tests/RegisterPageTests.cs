using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageAbstractions.Core.Templates;
using PageAbstractions.Core.Enumerators;
using System;
using System.Linq;

namespace PageAbstractions.UseCases.Tests
{
    [TestFixture]
    class RegisterPageTests
    {
        private IWebDriver driver;
        private RegisterPage registerPage;
        private string chromeDriverDirectory = @"C:\Users\Kaio\Documents\Projects\PageAbstractions\PageAbstractions\PageAbstractions.UseCases.Tests";
        private string url = "http://localhost:52058/Account/Register";

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver(chromeDriverDirectory);
            this.registerPage = new RegisterPage(url, driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void ICanRegister()
        {
            this
                .registerPage
                .FillEmail("Email", Locator.Id)
                .FillPassword("Password", "Teste@1234", Locator.Id)
                .ConfirmPassword("ConfirmPassword", Locator.Id)
                .Done("input[type='submit']", Locator.CssSelector);

            Assert.NotNull(registerPage.Find("a[title='Manage']", Locator.CssSelector));
        }

        [Test]
        public void ICantRegisterWithPasswordLowerThanSixCharacters()
        {
            this
                .registerPage
                .FillEmail("Email", Locator.Id)
                .FillPassword("Password", "foo", Locator.Id)
                .ConfirmPassword("ConfirmPassword", Locator.Id)
                .Done("input[type='submit']", Locator.CssSelector);

            Assert.NotZero(registerPage.FindAnyWhichMatches("li", Locator.TagName,
                (e) => e.Text == "The Password must be at least 6 characters long.").Count());

            Assert.Throws(typeof(NoSuchElementException),
                () => registerPage.Find("a[title='Manage']", Locator.CssSelector));
        }

        [Test]
        public void ICantRegisterWithPasswordWithoutSpecialCharacters()
        {
            this
                .registerPage
                .FillEmail("Email", Locator.Id)
                .FillPassword("Password", "testeteste", Locator.Id)
                .ConfirmPassword("ConfirmPassword", Locator.Id)
                .Done("input[type='submit']", Locator.CssSelector);

            string expectedMessage = "Passwords must have at least one non letter or digit character. Passwords must have at least one digit ('0'-'9'). Passwords must have at least one uppercase ('A'-'Z').";

            Assert.NotZero(registerPage.FindAnyWhichMatches("li", Locator.TagName,
                (e) => e.Text == expectedMessage).Count());

            Assert.Throws(typeof(NoSuchElementException),
                () => registerPage.Find("a[title='Manage']", Locator.CssSelector));
        }

        [Test]
        public void ICantRegisterWithPasswordsNotMatching()
        {
            this
                .registerPage
                .FillEmail("Email", Locator.Id)
                .FillPassword("Password", "testeteste", Locator.Id)
                .ConfirmPassword("ConfirmPassword", Locator.Id)
                .Done("input[type='submit']", Locator.CssSelector);

            string expectedMessage = "The password and confirmation password do not match.";
             
            Assert.NotZero(registerPage.FindAnyWhichMatches("li", Locator.TagName,
                (e) => e.Text == expectedMessage).Count());

            Assert.Throws(typeof(NoSuchElementException),
                () => registerPage.Find("a[title='Manage']", Locator.CssSelector));
        }

        [Test]
        public void ICantRegisterWithInvalidEmail()
        {
            this
                .registerPage
                .FillUsername("Email", Locator.Id)
                .FillPassword("Password", Locator.Id)
                .ConfirmPassword("ConfirmPassword", Locator.Id)
                .Done("input[type='submit']", Locator.CssSelector);
            
            Assert.NotZero(registerPage.FindAnyWhichMatches("li", Locator.TagName,
                (e) => e.Text == "O campo Email não é um endereço de email válido.").Count());

            Assert.Throws(typeof(NoSuchElementException),
                () => registerPage.Find("a[title='Manage']", Locator.CssSelector));
        }

        [TearDown]
        public void TearDown()
        {
            this.registerPage.Dispose();
        }
    }
}
