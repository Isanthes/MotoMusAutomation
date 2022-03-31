using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotoMusAutomation.PageModels
{
    class MyAccountPage : BasePage
    {
       
        const string myAccountLabel = ".side-menu > div:nth-child(1) > h3:nth-child(1)"; //css
        const string personalDataSelector = "ul.col-md-12:nth-child(4) > li:nth-child(2) > a:nth-child(1)"; //css
        const string personalDataLabel = ".account-section > div:nth-child(1)"; // css
        const string phoneLabel = "div.form-h:nth-child(4) > label:nth-child(1)"; // css
        const string phoneInput = "phone"; //name
        const string saveDataButton = "doSave"; //id
        const string validPersonalDataText = ".succes"; //css
        const string historyOrderLink = "/html/body/div[2]/div[3]/div/div[1]/div[2]/ul[2]/li[3]/a"; //xpath
        const string orderSelector = "keyword"; //id
        const string searchOrder = "__keywordSearch"; //id
        const string errorHistoryOrder = ".empty"; //css
        public MyAccountPage(IWebDriver driver) : base(driver)
        {
        }

        public Boolean CheckSearchLabel(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(myAccountLabel)).Text.ToLower());
        }

        public void AddPhoneNumber(string phoneNr)
        {
            var personalData = driver.FindElement(By.CssSelector(personalDataSelector));
            personalData.Click();
            var phoneNum = driver.FindElement(By.Name(phoneInput));
            phoneNum.Clear();
            phoneNum.SendKeys(phoneNr);
            var saveButton = driver.FindElement(By.Id(saveDataButton));
            saveButton.Submit();

        }
        public Boolean CheckValidPersonalDataText(string text)
        {
            return String.Equals(text.ToLower(), driver.FindElement(By.CssSelector(validPersonalDataText)).Text.ToLower());
        }

        public void CheckHistoryOrders(string orderNumber)
        {
            var historyOrder = driver.FindElement(By.XPath(historyOrderLink));
            historyOrder.Click();
            var orderElement = driver.FindElement(By.Id(orderSelector));
            orderElement.SendKeys(orderNumber);
            var searchElement = driver.FindElement(By.Id(searchOrder));
            searchElement.Click();

        }

        public Boolean CheckHistoryOrderErrorText(string text)
        {
            return String.Equals(text.ToLower(), driver.FindElement(By.CssSelector(errorHistoryOrder)).Text.ToLower());
        }
    }
}
