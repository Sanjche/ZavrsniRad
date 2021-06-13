using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ZavrsniRad.Lib;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ZavrsniRad
{
    class BasicTest
    {
         protected IWebDriver driver;
        protected WebDriverWait wait;

        protected void GoToURL(string url)
        {
            Logger.log("INFO", $"Opening URL:{url}");
            this.driver.Navigate().GoToUrl(url);
        }

        protected IWebElement MyFindElement(By Selector)
        {
            IWebElement ReturnElement = null;
            try
            {
                ReturnElement = this.driver.FindElement(Selector);
            }
            catch (NoSuchElementException)
            {
                Logger.log("ERROR:", $"Can't find element <{Selector}>");
            }
            if (ReturnElement != null)
            {
                Logger.log("INFO", $"Element <{Selector}>found");
            }
            return ReturnElement;
        }
        protected IWebElement WaitForElement(Func<IWebDriver, IWebElement> ExpectedConditions)
        {
            IWebElement ReturnElement = null;
            try
            {
                ReturnElement = this.wait.Until(ExpectedConditions);
            }
            catch (WebDriverTimeoutException)
            {
                Logger.log("ERROR:", $"Can't wait for {ReturnElement} element");
            }
            if (ReturnElement != null)
            {
                Logger.log("INFO", $"Element {ReturnElement} found");
            }
            return ReturnElement;
        }

        protected bool ElementExists(By selector)
        {
            IWebElement ReturnElement = null;
            try
            {
                ReturnElement = this.wait.Until(EC.ElementExists(selector));

            }
            catch (WebDriverTimeoutException)
            {
                Logger.log("ERROR:", $"Can't wait for {ReturnElement} element");
            }
            return ReturnElement != null;
        }
        public void PopulateInput(By selector, string TextToType)
        {
            Logger.log("INFO:", $"Populate input element:<{selector}>='{TextToType}'");
            IWebElement inputElement = this.MyFindElement(selector);
            inputElement.SendKeys(TextToType);
        }

        protected void ExplicitWait(int waitTime)
        {
            Logger.log("INFO:", $"Sleeping {waitTime}ms");
            System.Threading.Thread.Sleep(waitTime);
        }
    }
}
