﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace TC_01
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;

        [TestInitialize]
        public void TestSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(@"https://demo.opencart.com/");
        }

        [TestCleanup]
        public void TestTeardown()
        {
            driver.Quit();
        }

        [TestCategory("MenuCamerasButtonTesting")]
        [TestMethod]
        public void Test01NavigateToCameraPage()
        {
            var cameraButton = driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[7]/a"));

            cameraButton.Click();

            Thread.Sleep(1000);

            var cameraPageHeading = driver.FindElement(By.CssSelector("h2"));

            string expectedHeadingText = "Cameras";

            string actualHeadingText = cameraPageHeading.Text;

            Assert.AreEqual(expectedHeadingText, actualHeadingText);
        }

        [TestCategory("FooterContactUsButtonTesting")]
        [TestMethod]
        public void Test02NavigateToContactUsPage()
        {
            var footerContactUsButton = driver.FindElement(By.PartialLinkText("Contact Us"));

            footerContactUsButton.Click();

            Thread.Sleep(1000);

            var contactUsPageHeading = driver.FindElement(By.CssSelector("#content h1"));

            string expectedHeadingText = "Contact Us";

            string actualHeadingText = contactUsPageHeading.Text;

            Assert.AreEqual(expectedHeadingText, actualHeadingText);
        }

        [TestCategory("SearchTextboxTesting")]
        [TestMethod]
        public void Test03NavigateToSearchResultsPage()
        {
            var searchTextbox = driver.FindElement(By.XPath("//*[@id='search']/input"));

            searchTextbox.Clear();
            Thread.Sleep(2000);

            searchTextbox.SendKeys("iPhone");
            Thread.Sleep(2000);

            var findButton = driver.FindElement(By.XPath("//*[@id='search']/span/button"));

            findButton.Click();

            Thread.Sleep(2000);

            var searchResultPage = driver.FindElement(By.PartialLinkText("iPhone"));

            string expectedHeadingText = "iPhone";

            string actualHeadingText = searchResultPage.Text;

            Assert.AreEqual(expectedHeadingText, actualHeadingText);
        }

        [TestCategory("OrderGoodsTesting")]
        [TestMethod]
        public void Test04AddGoodsToCard()
        {
            var addToCardMacBook = driver.FindElement(By.XPath("//*[@id='content']/div[2]/div[1]/div/div[3]/button[1]"));

            addToCardMacBook.Click();

            Thread.Sleep(2000);

            var addToCardIPhone = driver.FindElement(By.XPath("//*[@id='content']/div[2]/div[2]/div/div[3]/button[1]"));

            addToCardIPhone.Click();

            Thread.Sleep(2000);

            var basketButton = driver.FindElement(By.XPath("//*[@id='cart']/button"));

            basketButton.Click();

            Thread.Sleep(1000);

            var totalSum = driver.FindElement(By.XPath("//*[@id='cart']/ul/li[2]/div/table/tbody/tr[4]/td[2]"));

            string expectedItemsAndPrice = "$725.20";

            string actualItemsAndPrice = totalSum.Text;

            Assert.AreEqual(expectedItemsAndPrice, actualItemsAndPrice);

            var iPhoneInBasket = driver.FindElement(By.XPath("//*[@id='cart']/ul/li[1]/table/tbody/tr[1]/td[2]/a"));

            string expectedFirstItem = "iPhone";

            string actualFirstItem = iPhoneInBasket.Text;

            Assert.AreEqual(expectedFirstItem, actualFirstItem);

            var macBookInBasket = driver.FindElement(By.XPath("//*[@id='cart']/ul/li[1]/table/tbody/tr[2]/td[2]/a"));

            string expectedSecondItem = "MacBook";

            string actualSecondItem = macBookInBasket.Text;

            Assert.AreEqual(expectedSecondItem, actualSecondItem);
        }

        [TestCategory("ContactFormTesting")]
        [TestMethod]
        public void Test05SendEnquiryUsingContactForm()
        {
            var footerContactUsButton = driver.FindElement(By.PartialLinkText("Contact Us"));

            footerContactUsButton.Click();

            Thread.Sleep(1000);

            var yourName = driver.FindElement(By.CssSelector("#input-name"));

            yourName.Clear();
            yourName.SendKeys("Ivaylo Apostolov");

            var emailAddress = driver.FindElement(By.CssSelector("#input-email"));

            emailAddress.Clear();
            emailAddress.SendKeys("ivaylo.apostolov@gmail.com");

            var enquiry = driver.FindElement(By.CssSelector("#input-enquiry"));

            enquiry.Clear();
            enquiry.SendKeys("This is a test");

            var submitButton = driver.FindElement(By.CssSelector("input[type='submit']"));

            submitButton.Click();

            Thread.Sleep(2000);

            var submitPageHeading = driver.FindElement(By.CssSelector("#content h1"));

            string expectedHeadingText = "Contact Us";

            string actualHeadingText = submitPageHeading.Text;

            Assert.AreEqual(expectedHeadingText, actualHeadingText);
        }

        [TestCategory("CompareProductsTesting")]
        [TestMethod]
        public void Test06CompareTwoProducts()
        {
            var compareFirstProduct = driver.FindElement(By.XPath("//*[@id='content']/div[2]/div[1]/div/div[3]/button[3]"));

            var firstProduct = driver.FindElement(By.XPath("//*[@id='content']/div[2]/div[1]/div/div[2]/h4/a"));

            string firstProductName = firstProduct.Text;

            compareFirstProduct.Click();

            Thread.Sleep(3000);

            var compareSecondProduct = driver.FindElement(By.XPath("//*[@id='content']/div[2]/div[2]/div/div[3]/button[3]"));

            var secondProduct = driver.FindElement(By.XPath("//*[@id='content']/div[2]/div[2]/div/div[2]/h4/a"));

            string secondProductName = secondProduct.Text;

            compareSecondProduct.Click();

            Thread.Sleep(3000);

            //click on "product comparison"
            
            var productComparison = driver.FindElement(By.PartialLinkText("product comparison"));

            productComparison.Click();

            Thread.Sleep(2000);

            var comparisonFirstProduct = driver.FindElement(By.XPath("//*[@id='content']/table/tbody[1]/tr[1]/td[2]/a/strong"));

            string comparisonFirstProductName = comparisonFirstProduct.Text;

            var comparisonSecondProduct = driver.FindElement(By.XPath("//*[@id='content']/table/tbody[1]/tr[1]/td[3]/a/strong"));

            string comparisonSecondProductName = comparisonSecondProduct.Text;

            Assert.AreEqual(firstProductName, comparisonFirstProductName);

            Assert.AreEqual(secondProductName, comparisonSecondProductName);
        }
    }
}
