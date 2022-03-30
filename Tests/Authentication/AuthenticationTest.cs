using MotoMusAutomation.Utilities;
using NUnit.Framework;
using MotoMusAutomation.Tests;
using System;
using System.Collections.Generic;
using System.Text;
using MotoMusAutomation.PageModels;
using System.IO;

namespace MotoMusAutomation.Tests.Authentication
{
    public class AuthenticationTest : BaseTest 
    {
        string url = FrameworkConstants.GetUrl();
        private static IEnumerable<TestCaseData> GetAuthenticationDataCsv()
        {
            foreach (var values in Utils.GetGenericData("TestData\\authenticationData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }
        private static IEnumerable<TestCaseData> GetInvalidAuthenticationDataCsv()
        {
            foreach (var values in Utils.GetGenericData("TestData\\invalidauthData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }


        [Test, TestCaseSource("GetAuthenticationDataCsv")]
        public void AuthenticationHappyFlow(string email, string pass)
        {
            _driver.Navigate().GoToUrl(url);
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            AuthenticationPage happyFlow = new AuthenticationPage(_driver);
            Assert.IsTrue(happyFlow.CheckAuthenticationLabel("CONTUL TAU"));
            Assert.AreEqual("Ai mai cumparat de la noi sau esti deja inregistrat?", happyFlow.getLabel(happyFlow.getAuthText()));
            Assert.AreEqual("Email", happyFlow.getLabel(happyFlow.getEmailLabel()));
            Assert.AreEqual("Parola", happyFlow.getLabel(happyFlow.getPassLabel()));
            happyFlow.ValidLogin(email, pass);
        }


        [Test, TestCaseSource("GetInvalidAuthenticationDataCsv")]

        public void InvalidAuthentication(string email, string pass)
        {
            _driver.Navigate().GoToUrl(url);
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            AuthenticationPage invalidAuth = new AuthenticationPage(_driver);
            Assert.IsTrue(invalidAuth.CheckAuthenticationLabel("CONTUL TAU"));
            invalidAuth.ValidLogin(email,pass);
            Assert.IsTrue(invalidAuth.getLoginError("Adresa de e-mail / parola introduse sunt incorecte. Te rugam sa incerci din nou."));
            
        }
    }
}
