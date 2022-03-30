using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace MotoMusAutomation.PageModels
{
    public class AuthenticationPage : BasePage
    {
        const string authPageSelector = ".old-client-section-h > div:nth-child(1) > h1:nth-child(1)"; //css
        const string authButtonSelector = "li.-g-user-icon:nth-child(1) > a:nth-child(1)"; //css
        const string authTextSelector = "div.regular-text"; //css
        const string loginErrorSelector = ".error"; //css

        const string emailLabel = "div.register-form:nth-child(3) > form:nth-child(1) > div:nth-child(1) > label:nth-child(1)"; //css
        const string emailInput = "_loginEmail"; //id

        const string passwordLabel = "div.register-form:nth-child(3) > form:nth-child(1) > div:nth-child(2) > label:nth-child(1)"; //css
        const string passwordInput = "_loginPassword"; //id

        const string loginButton = "doLogin"; //id
        const string recovPassSelector = "client-pass-recov"; //class
        const string acceptCookiesButton = "__gomagCookiePolicy"; //id


        public AuthenticationPage (IWebDriver driver) : base(driver)
        {
        }


        public Boolean CheckAuthenticationLabel(string label)
        {
            var acceptCookies = driver.FindElement(By.Id(acceptCookiesButton));
            acceptCookies.Click();       
            var loginElement = driver.FindElement(By.CssSelector(authButtonSelector));
            loginElement.Click();
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(authPageSelector)).Text.ToLower());
  
        }

        public void ValidLogin(string email, string pass)
        {

            var emailElement = driver.FindElement(By.Id(emailInput));
            emailElement.Clear();
            emailElement.SendKeys(email);

            var passElement = driver.FindElement(By.Id(passwordInput));
            passElement.Clear();
            passElement.SendKeys(pass);

            var loginSubmitButton = driver.FindElement(By.Id(loginButton));
            loginSubmitButton.Submit();

        }
        public Boolean getLoginError(string error)
        {
            return String.Equals(error.ToLower(), driver.FindElement(By.CssSelector(loginErrorSelector)).Text.ToLower());
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
        public string getPassLabel()
        {
            return passwordLabel;
        }
        public string getAuthText()
        {
            return authTextSelector;
        }


    }
}

