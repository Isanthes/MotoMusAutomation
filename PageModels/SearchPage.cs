using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MotoMusAutomation.PageModels
{
    public class SearchPage : BasePage
    {
        const string searchBoxSelector = "_autocompleteSearchMainHeader"; //id
        const string searchIconSelector = "_doSearch"; //id
        const string acceptCookiesButton = "__gomagCookiePolicy"; //id

        const string echipamenteSelector = "ul.nav-menu:nth-child(1) > li:nth-child(1) > a:nth-child(1)"; //css
        const string castiSelector = "div.column2:nth-child(2) > ul:nth-child(1) > li:nth-child(2) > span:nth-child(1) > p:nth-child(1) > a:nth-child(1)"; //css
        const string castiTitle = "div.-g-category-sidebar-categories:nth-child(1) > div:nth-child(1) > p:nth-child(1)"; //css

        const string iconGroupSelector = ".icon-group"; //css
        const string transportIconSelector = ".icon-g-scroll > div:nth-child(1) > div:nth-child(1) > a:nth-child(1)"; //css
        const string transportTextSelector = ".icon-g-scroll > div:nth-child(1) > div:nth-child(1) > a:nth-child(1) > div:nth-child(3)"; //css
        const string payMethodsIconSelector = ".icon-g-scroll > div:nth-child(2) > div:nth-child(1) > a:nth-child(1)"; //css
        const string payMethodsTextSelector = ".icon-g-scroll > div:nth-child(2) > div:nth-child(1) > a:nth-child(1) > div:nth-child(3)"; //css
        const string motoWarrantyIconSelector = ".icon-g-scroll > div:nth-child(3) > div:nth-child(1) > a:nth-child(1)"; //css
        const string motoWarrantyTextSelector = ".icon-g-scroll > div:nth-child(3) > div:nth-child(1) > a:nth-child(1) > div:nth-child(3)"; //css
        const string damagedProductsWarrantyIcon = ".icon-g-scroll > div:nth-child(4) > div:nth-child(1) > a:nth-child(1)"; //css
        const string damagedProductsWarrantyText = ".icon-g-scroll > div:nth-child(4) > div:nth-child(1) > a:nth-child(1) > div:nth-child(3)"; //css



        public SearchPage(IWebDriver driver) : base(driver)
        {
        }

        public void SearchInSite(string element)
        {
            var searchBoxElement = driver.FindElement(By.Id(searchBoxSelector));
            searchBoxElement.SendKeys(element);
            var searchIconElement = driver.FindElement(By.Id(searchIconSelector));
            searchIconElement.Click();
        }

        public string HoverOverInfoIcons()
        {
            var acceptCookies = driver.FindElement(By.Id(acceptCookiesButton));
            acceptCookies.Click();
            var transportIcon = driver.FindElement(By.CssSelector(transportIconSelector));
            Actions action = new Actions(driver);
            action.MoveToElement(transportIcon).Build().Perform();

            var transportText = driver.FindElement(By.CssSelector(transportTextSelector));
            string theText = transportText.Text;
            return theText;
        }

        public void MenuIcon()
        {
            var echiamenteIcon = driver.FindElement(By.CssSelector(echipamenteSelector));
            Actions action = new Actions(driver);
            action.MoveToElement(echiamenteIcon).Build().Perform();
            var casti = driver.FindElement(By.CssSelector(castiSelector));
            casti.Click();

        }
        public string getCastiTitle()
        {
            var casti = driver.FindElement(By.CssSelector(castiTitle));
            return casti.Text;
        }

      /*public void HoverOverInfoIcons1()
        {
             var icon = driver.FindElements(By.CssSelector(iconGroupSelector));
            Actions action = new Actions(driver);
            foreach (var i in icon)
            { 
                //IWebElement something = i.FindElement(By.CssSelector(".icon-group"));
                action.MoveToElement(i).Build().Perform();
                Thread.Sleep(10000);
            }
        }*/
    }
}
