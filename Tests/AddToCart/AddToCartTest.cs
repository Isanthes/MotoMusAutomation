using MotoMusAutomation.PageModels;
using MotoMusAutomation.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotoMusAutomation.Tests.Equipment
{
    class AddToCartTest : BaseTest
    {
        string url = FrameworkConstants.GetUrl();
        [Test]
        public void AddToCartFromPromotii()
        {
            _driver.Navigate().GoToUrl(url);
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            AddToCartPage cp = new AddToCartPage(_driver);
            Assert.IsTrue(cp.CheckPromotiiLabel("PROMOTII"));
            cp.ProductAddToCart("Cele mai noi");
            
        }

        [Test]
        public void CheckNoProductInCart()
        {
            _driver.Navigate().GoToUrl(url);
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            AddToCartPage cp = new AddToCartPage(_driver);
            cp.CheckCart();
            Assert.IsTrue(cp.CheckCardText("Nu exista produse in cosul tau de cumparaturi."));

        }
    }
}
