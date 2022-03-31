using MotoMusAutomation.PageModels;
using MotoMusAutomation.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotoMusAutomation.Tests.MyAccount
{
    class MyAccountTest : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Test]
        public void AddValidPhoneNumber()
        {
            _driver.Navigate().GoToUrl(url);
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            AuthenticationPage happyFlow = new AuthenticationPage(_driver);
            Assert.IsTrue(happyFlow.CheckAuthenticationLabel("CONTUL TAU"));
            happyFlow.ValidLogin("ernest32@gmail.com", "MageFighter31");

            MyAccountPage ap = new MyAccountPage (_driver);
            Assert.IsTrue(ap.CheckSearchLabel("CONTUL MEU"));
            ap.AddPhoneNumber(Utils.GenerateRendomStringCount(10));
            Assert.IsTrue(ap.CheckValidPersonalDataText("Datele personale au fost salvate cu succes."));
        }
        [Test]
        public void SearchHistoryOrder()
        {
            _driver.Navigate().GoToUrl(url);
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            AuthenticationPage happyFlow = new AuthenticationPage(_driver);
            Assert.IsTrue(happyFlow.CheckAuthenticationLabel("CONTUL TAU"));
            happyFlow.ValidLogin("ernest32@gmail.com", "MageFighter31");

            MyAccountPage accpage = new MyAccountPage(_driver);
            accpage.CheckHistoryOrders(Utils.GenerateRendomStringCount(8));
            Assert.IsTrue(accpage.CheckHistoryOrderErrorText("Ne pare rau, nu am gasit comenzi care sa se potriveasca cu cautarea ta"));

        }

    }
}
