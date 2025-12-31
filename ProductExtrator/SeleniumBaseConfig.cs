using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductExtrator
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public abstract class SeleniumBaseConfig : ClasseBase, IDisposable
    {
        protected IWebDriver Driver { get; private set; }
        protected IJavaScriptExecutor Js => (IJavaScriptExecutor)Driver;

        protected SeleniumBaseConfig(bool headless = true)
        {
            Driver = CreateDriver(headless);
        }

        private IWebDriver CreateDriver(bool headless)
        {
            var options = new ChromeOptions();

            if (headless)
                //options.AddArgument("--headless=new");

            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--disable-blink-features=AutomationControlled");

            // Evita alguns bloqueios básicos
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalOption("useAutomationExtension", false);

            return new ChromeDriver(options);
        }

        public void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Dispose()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }

}
