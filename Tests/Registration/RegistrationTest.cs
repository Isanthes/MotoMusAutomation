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
    public class RegistrationTest : BaseTest
    {
        string url = FrameworkConstants.GetUrl();
        private static IEnumerable<TestCaseData> GetValidRegistrationDataCsv()
        {
            foreach (var values in Utils.GetGenericData("TestData\\validRegistrationData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Test, TestCaseSource("GetValidRegistrationDataCsv")]
        public void ValidRegistration(string email, string nume, string prenume, string parola, string confirmParola)
        {
            _driver.Navigate().GoToUrl(url);
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            RegistrationPage happyFlow = new RegistrationPage(_driver);
            Assert.IsTrue(happyFlow.CheckRegistrationLabel("CLIENT NOU: INREGISTRARE"));
            Assert.AreEqual("Inregistreaza-te si cumperi mai repede si mai simplu. Beneficiezi de promotii si oferte promotionale " +
                "exclusive clientilor inregistrati.", happyFlow.CheckPageText());
            Assert.AreEqual("Email*", happyFlow.getLabel(happyFlow.getEmailLabel()));
            Assert.AreEqual("Nume*", happyFlow.getLabel(happyFlow.getNumeLabel()));
            Assert.AreEqual("Prenume*", happyFlow.getLabel(happyFlow.getPrenumeLabel()));
            Assert.AreEqual("Parola*", happyFlow.getLabel(happyFlow.getParolaLabel()));
            Assert.AreEqual("Confirma parola*", happyFlow.getLabel(happyFlow.getConfirmParolaLabel()));
            happyFlow.ValidRegistration(email, nume, prenume, parola, confirmParola);
        }

        [Test]
        public void RegistrationMandatoryValues ()
        {
            _driver.Navigate().GoToUrl(url + "/inregistrare");
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            RegistrationPage errorMessage = new RegistrationPage(_driver);
            Assert.AreEqual("Va rugam sa completati toate campurile obligatorii.", errorMessage.getError(errorMessage.getMandatoryError()));
            Assert.AreEqual("Adresa de email este obligatorie.", errorMessage.getError(errorMessage.getEmailError()));
            Assert.AreEqual("Numele este obligatoriu.", errorMessage.getError(errorMessage.getNumeError()));
            Assert.AreEqual("Prenumele este obligatoriu.", errorMessage.getError(errorMessage.getPrenumeError()));
            Assert.AreEqual("Parola este obligatorie.", errorMessage.getError(errorMessage.getParolaError()));
            Assert.AreEqual("Parolele nu corespund.", errorMessage.getError(errorMessage.getConfirmParolaError()));
            

        }
    }
}
