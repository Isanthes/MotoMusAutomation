using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace MotoMusAutomation.PageModels
{
    public class RegistrationPage : BasePage
    {
        const string authButtonSelector = "li.-g-user-icon:nth-child(1) > a:nth-child(1)"; //css
        const string registrationPageTitle = ".new-client-section > div:nth-child(1) > h1:nth-child(1)"; //css
        const string registrationPageText = "p.regular-text"; //css

        const string emailLabel = ".form-reg-h > div:nth-child(1) > label:nth-child(1)"; //css
        const string emailInput = "__emailRegister"; //id
        const string emailMandatoryErr = ".form-reg-h > div:nth-child(1) > span:nth-child(4)"; //css

        const string numeLabel = ".form-reg-h > div:nth-child(2) > label:nth-child(1)"; //css
        const string numeInput = "__lastnameRegister"; //id
        const string numeMandatoryErr = ".form-reg-h > div:nth-child(2) > span:nth-child(4)"; //css

        const string prenumeLabel = ".form-reg-h > div:nth-child(3) > label:nth-child(1)"; //css
        const string prenumeInput = "__firstnameRegister"; //id
        const string prenumeMandatoryErr = ".form-reg-h > div:nth-child(3) > span:nth-child(4)"; //css

        const string parolaLabel = ".form-reg-h > div:nth-child(4) > label:nth-child(1)"; //css
        const string parolaInput = "__passwordRegister"; //id
        const string parolaMandatoryErr = ".form-reg-h > div:nth-child(4) > span:nth-child(4)"; //css

        const string confirmParolaLabel = "div.col:nth-child(5) > label:nth-child(1)"; //css
        const string confirmParolaInput = "__confirmPasswordRegister"; //id
        const string confirmParolaErr = "div.col:nth-child(5) > span:nth-child(4)"; //css

        const string newsletterSelelctor = "label.-g-agreement-NewsletterInformation:nth-child(6) > div:nth-child(1) > input:nth-child(1)"; //css
        const string gdprAgree = ".-g-agreement-PersonalInformation > div:nth-child(1) > input:nth-child(1)"; //css
        const string registrationButton = "doRegister"; //id
        const string registrationError = "p.regular-text:nth-child(1)"; //css

        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }


        public Boolean CheckRegistrationLabel(string label)
        {
            var registrationSubmitButton = driver.FindElement(By.Id(registrationButton));
            registrationSubmitButton.Submit();
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(registrationPageTitle)).Text.ToLower());

        }
        public string CheckPageText()
        {
            return driver.FindElement(By.CssSelector(registrationPageText)).Text;
        }

        public void ValidRegistration(string email,string nume, string prenume, string parola, string confirmParola)
        {      
            var emailElement = driver.FindElement(By.Id(emailInput));
            emailElement.Clear();
            emailElement.SendKeys(email);

            var nameElement = driver.FindElement(By.Id(numeInput));
            nameElement.Clear();
            nameElement.SendKeys(nume);

            var prenumeElement = driver.FindElement(By.Id(prenumeInput));
            prenumeElement.Clear();
            prenumeElement.SendKeys(prenume);

            var passElement = driver.FindElement(By.Id(parolaInput));
            passElement.Clear();
            passElement.SendKeys(parola);

            var confirmParolaElement = driver.FindElement(By.Id(confirmParolaInput));
            confirmParolaElement.Clear();
            confirmParolaElement.SendKeys(confirmParola);

            var newsletterElement = driver.FindElement(By.CssSelector(newsletterSelelctor));
            newsletterElement.Click();

            var gdprAcceptElement = driver.FindElement(By.CssSelector(gdprAgree));
            gdprAcceptElement.Click();

            var loginSubmitButton = driver.FindElement(By.Id(registrationButton));
            loginSubmitButton.Submit();

        }


        public string getLabel(string label)
        {
            var element = driver.FindElement(By.CssSelector(label));
            return element.Text;
        }
        public string getEmailLabel()
        {
            return emailLabel;
        }
        public string getNumeLabel()
        {
            return numeLabel;
        }
        public string getPrenumeLabel()
        {
            return prenumeLabel;
        }
        public string getParolaLabel()
        {
            return parolaLabel;
        }
        public string getConfirmParolaLabel()
        {
            return confirmParolaLabel;
        }

        public string getError(string error)
        {
            var loginSubmitButton = driver.FindElement(By.Id(registrationButton));
            loginSubmitButton.Submit();
            var element = driver.FindElement(By.CssSelector(error));
            return element.Text;
        }
        public string getMandatoryError()
        {
            return registrationError;
        }
        public string getEmailError()
        {
            return emailMandatoryErr;
        }
        public string getNumeError()
        {
            return numeMandatoryErr;
        }
        public string getPrenumeError()
        {
            return prenumeMandatoryErr;
        }
        public string getParolaError()
        {
            return parolaMandatoryErr;
        }
        public string getConfirmParolaError()
        {
            return confirmParolaErr;
        }

    }
}

