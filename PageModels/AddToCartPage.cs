using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotoMusAutomation.PageModels
{
    class AddToCartPage : BasePage
    {
        const string promotiiLabel = "ul.nav-menu:nth-child(1) > li:nth-child(10) > a:nth-child(1)"; //css
        const string promotiiPageTextSelector = ".catTitle"; //css
        const string ordoneazaSelector = "input-s"; //class
        const string productSelector = "._productMainImage_52591"; //css
        const string sizeSelector = ".input-s"; //css
        const string plusQuantitySelector = "qtyplus"; //id
        const string minusQuantitySelector = "qtyminus"; //id
        const string addtocartSelector = "a.btn:nth-child(2)"; //css
        const string cartIconSelector = ".cart-drop > i:nth-child(2)"; //css
        const string noProductInCartText = ".regular-txt"; //css
        const string seeCartSelector = "a.btn:nth-child(7)"; //class



        public AddToCartPage(IWebDriver driver) : base(driver)
        {
        }
        public Boolean CheckPromotiiLabel(string label)
        {
            var promotiiElement = driver.FindElement(By.CssSelector(promotiiLabel));
            promotiiElement.Click();
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(promotiiPageTextSelector)).Text.ToLower());
        }
        public void ProductAddToCart(string text)
        {
            var selectElement = new SelectElement(driver.FindElement(By.ClassName(ordoneazaSelector)));
            selectElement.SelectByText(text);
            var productElement = driver.FindElement(By.CssSelector(productSelector));
            productElement.Click();
            //var sizeElement = driver.FindElement(By.CssSelector(sizeSelector));
            //sizeElement.Click();
            for (int i = 0; i < 3; i++)
            {
                var button = driver.FindElement(By.Id(plusQuantitySelector));
                button.Click();
            }
            var addToCartElement = driver.FindElement(By.CssSelector(addtocartSelector));
            addToCartElement.Click();
            var cartElement = driver.FindElement(By.CssSelector(cartIconSelector));
            cartElement.Click();
            var seeCartElement = driver.FindElement(By.CssSelector(seeCartSelector));
            seeCartElement.Click();
        }

        public void CheckCart()
        {
            var checkCartElement = driver.FindElement(By.CssSelector(cartIconSelector));
            checkCartElement.Click();

        }
        public Boolean CheckCardText(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(noProductInCartText)).Text.ToLower());
        }
    }
}
