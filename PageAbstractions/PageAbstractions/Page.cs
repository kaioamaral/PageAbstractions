using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageAbstractions.Enumerators;
using System;

namespace PageAbstractions
{
    public abstract class Page
    {
        public IWebDriver driver;
        private TimeSpan defaultTimeSpan;

        public Page(IWebDriver driver, TimeSpan defaultTimeSpan)
        {
            this.driver = driver;
            this.defaultTimeSpan = defaultTimeSpan;
        }

        public Page NavigateTo(string url, string proofElement, Locator locator)
        {
            driver.Navigate().GoToUrl(url);
            new WebDriverWait(driver, this.defaultTimeSpan)
                .Until(d => d.FindElement(BuildWayToFind(proofElement, locator)));

            return this;
        }

        public IWebElement Find(string element, Locator locator)
        {
            return driver.FindElement(BuildWayToFind(element, locator));
        }

        public Page Fill(string element, string value, Locator locator)
        {
            Find(element, locator).Clear();
            Find(element, locator).SendKeys(value);
            return this;
        }

        public Page SelectByTextIn(string element, string text, Locator locator)
        {
            new SelectElement(Find(element, locator)).SelectByText(text);
            return this;
        }

        public Page SelectByValueIn(string element, string value, Locator locator)
        {
            new SelectElement(Find(element, locator)).SelectByValue(value);
            return this;
        }

        public Page WaitUntil<TResult>(Func<IWebDriver, TResult> condiction)
        {
            new WebDriverWait(driver, this.defaultTimeSpan).Until(condiction);
            return this;
        }

        public void Click(string element, Locator locator)
        {
            driver.FindElement(BuildWayToFind(element, locator)).Click();
        }

        private By BuildWayToFind(string element, Locator locator)
        {
            switch (locator)
            {
                case Locator.Id:
                    return By.Id(element);
                case Locator.Name:
                    return By.Name(element);
                case Locator.CssSelector:
                    return By.CssSelector(element);
                default:
                    throw new Exception("Coudn't find a way to query the requested element.");
            }
        }
    }
}
