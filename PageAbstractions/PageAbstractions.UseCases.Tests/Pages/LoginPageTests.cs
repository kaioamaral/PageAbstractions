using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using PageAbstractions.Core.Enumerators;
using PageAbstractions.Core.Templates;
using PageAbstractions.UseCases.Tests.Abstractions;
using System;

namespace PageAbstractions.UseCases.Tests
{
    class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    class LoginPageTests : PageTests
    {
        private LoginPage loginPage;
        private User user;

        [SetUp]
        public override void Setup()
        {
            this.user = new User() { Email = "test@test.com", Password = "Teste@1234" };

            var registerPage = new RegisterPage("http://localhost:52058/Account/Register",
                new ChromeDriver(base.chromeDriverDirectory),
                TimeSpan.FromSeconds(10));

            registerPage
                .FillEmail("Email", Locator.Id)
                .FillPassword("Password", Locator.Id)
                .ConfirmPassword("Password", Locator.Id)
                .ClickToSubmit("input[type='submit'", Locator.CssSelector);
            
            loginPage = new LoginPage(
                new ChromeDriver(base.chromeDriverDirectory), 
                TimeSpan.FromSeconds(10),
                "http://localhost:52058/Account/Login");
        }

        [Test]
        public void ICanLogin()
        {
            this
                .loginPage
                .FillEmail("Email", this.user.Email, Locator.Id)
                .FillPassword("Password", this.user.Password, Locator.Id)
                .SubmitByClickingIn("input[type='submit']", Locator.CssSelector);
        }

        [TearDown]
        public override void TearDown()
        {
            this.loginPage.Dispose();
        }
    }
}
