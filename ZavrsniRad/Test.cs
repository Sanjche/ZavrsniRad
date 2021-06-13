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
    class Test : BasicTest
    {
        [SetUp]
        public void SetUp()
        {
            Logger.setFileName(@"C:\Kurs\ZavrsniRad.log");
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
            this.wait = new WebDriverWait(this.driver, new TimeSpan(0, 0, 10));

        }

        [TearDown]
        public void TearDown()
        {
            this.driver.Close();
        }

        [Test]

        public void LogIn()
        {
            Logger.log("INFO:", "Starting LogIn test");
            this.GoToURL("http://test.qa.rs/");

            IWebElement fastFood = this.WaitForElement(EC.ElementIsVisible(By.XPath("//h1[contains(., FastFood)]")));
            Assert.IsTrue(fastFood.Displayed);

            IWebElement linkLogin = this.MyFindElement(By.LinkText("Login"));
            linkLogin.Click();

            IWebElement msgLogin = this.WaitForElement(EC.ElementIsVisible(By.XPath("//h2[contains(., Login)]")));
            Assert.IsTrue(msgLogin.Displayed);

            this.PopulateInput(By.Name("username"), "sanjche");
            this.PopulateInput(By.Name("password"), "kaja");

            IWebElement btnLogin = this.MyFindElement(By.Name("login"));
            btnLogin.Click();

            IWebElement greetingmsg = this.WaitForElement(EC.ElementIsVisible(By.XPath("//h2[contains(., Welcome)]")));
            Assert.IsTrue(greetingmsg.Displayed);


           }

        [Test]

        public void RegisterAndCheckout()
        {
            Logger.log("INFO:", "Starting RegisterAndCheckout test");
            this.GoToURL("http://test.qa.rs/");


            IWebElement linkLogin = this.MyFindElement(By.LinkText("Login"));
            linkLogin.Click();

            this.PopulateInput(By.Name("username"), "sanjche");
            this.PopulateInput(By.Name("password"), "kaja");

            IWebElement btnLogin = this.MyFindElement(By.Name("login"));
            btnLogin.Click();


            IWebElement burger = this.MyFindElement
                (By.XPath("//div//h3[contains(text(), 'Burger')]//ancestor::div[contains(@class, 'panel')]//input[@type='submit']"));
            burger.Click();

            IWebElement continueShopping = this.MyFindElement(By.LinkText("Continue shopping"));
            continueShopping.Click();

            

            IWebElement megaBurger = this.MyFindElement
                (By.XPath("//div//h3[contains(text(), 'Mega')]//ancestor::div[contains(@class, 'panel')]//input[@type='submit']"));
            megaBurger.Click();

            IWebElement continueS = this.MyFindElement(By.LinkText("Continue shopping"));
            continueS.Click();

            IWebElement heartAtack = this.MyFindElement
                (By.XPath("//div//h3[contains(text(), 'Heart')]//ancestor::div[contains(@class, 'panel')]//input[@type='submit']"));
            heartAtack.Click();

            IWebElement btnCheckout = this.WaitForElement(EC.ElementToBeClickable(By.Name("checkout")));

            IWebElement totalCh = this.MyFindElement(By.XPath("//td[contains(., 'Total')]"));
            string cartTotal = totalCh.Text.Replace("Total: ", "");
            btnCheckout.Click();

            IWebElement totalOr = this.MyFindElement(By.XPath("//h3[contains(., '$')]"));

            string orderTotal = totalOr.Text.Replace("Your credit card has been charged with the amount of ", "");

            Logger.log("info", $"{orderTotal}");
            Assert.AreEqual(cartTotal, orderTotal);
                
        }

        [Test]

        public void LogOut()
        {
            this.GoToURL("http://test.qa.rs/");
            IWebElement linkLogin = this.MyFindElement(By.LinkText("Login"));
            linkLogin.Click();

            this.PopulateInput(By.Name("username"), "sanjche");
            this.PopulateInput(By.Name("password"), "kaja");

            IWebElement btnLogin = this.MyFindElement(By.Name("login"));
            btnLogin.Click();

            IWebElement linkLogout = this.MyFindElement(By.PartialLinkText("Logout"));
            linkLogout.Click();


            IWebElement linkLogIn = this.MyFindElement(By.LinkText("Login"));

            Assert.IsTrue(linkLogIn.Displayed);


        }

    }
}
