using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Dodo
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            baseURL = "https://rabotavdodo.ru/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void UnitTest1()
        {
            


            driver.Navigate().GoToUrl(baseURL + "/Applicants/New");
            driver.FindElement(By.XPath("//button[@onclick=\"GoToForm();yaCounter36223035.reachGoal('ClickButtonToWorkOneScreen');return true;\"]")).Click();
            new SelectElement(driver.FindElement(By.Name("localityId"))).SelectByText("Москва");
            driver.FindElement(By.Id("name_01")).Clear();
            driver.FindElement(By.Id("name_01")).SendKeys("тестовый");
            driver.FindElement(By.Id("name_02")).Clear();
            driver.FindElement(By.Id("name_02")).SendKeys("тест");
            new SelectElement(driver.FindElement(By.Id("birthday_day"))).SelectByText("1");
            new SelectElement(driver.FindElement(By.Id("birthday_month"))).SelectByText("Январь");
            new SelectElement(driver.FindElement(By.Id("birthday_year"))).SelectByText("2000");
            driver.FindElement(By.Id("address")).Clear();
            driver.FindElement(By.Id("address")).SendKeys("Москва");
            driver.FindElement(By.Id("phonenumber")).Click();
            driver.FindElement(By.Id("phonenumber")).Clear();
            driver.FindElement(By.Id("phonenumber")).SendKeys("9041111111");
            driver.FindElement(By.Id("unit_665")).Click();
            driver.FindElement(By.CssSelector("label[for=position_1138]")).Click();
            driver.FindElement(By.Id("worktime_1")).Click();
            new SelectElement(driver.FindElement(By.Id("applicantSource"))).SelectByText("Соцсети (vkontakte, facebook)");
            driver.FindElement(By.Id("socialLink")).Clear();
            driver.FindElement(By.Id("socialLink")).SendKeys("1");
            driver.FindElement(By.Name("Oferta")).Click();
            driver.FindElement(By.Id("send")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
