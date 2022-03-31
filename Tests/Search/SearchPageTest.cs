using MotoMusAutomation.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using MotoMusAutomation.PageModels;

namespace MotoMusAutomation.Tests.Search
{
    public class SearchPageTest : BaseTest
    {
        string url = FrameworkConstants.GetUrl();
        

        private static IEnumerable<TestCaseData> GetSearchDataCsv()
        {
            foreach (var values in Utils.GetGenericData("TestData\\searchData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Test, TestCaseSource("GetSearchDataCsv")]
        public void SearchBox(string searchValue)
        {
            _driver.Navigate().GoToUrl(url);
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            SearchPage sp = new SearchPage(_driver);
            sp.SearchInSite(searchValue);

        }

        [Test]
        public void HoverIcons()
        {
            _driver.Navigate().GoToUrl(url);
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);

            SearchPage sp = new SearchPage(_driver);
            Assert.AreEqual("Posibilitate de transport la nivel național, inclusiv pentru vehicule!", sp.HoverOverInfoIcons());
        }

        [Test]
        public void HoverMenuIcons()
        {
            _driver.Navigate().GoToUrl(url);
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);

            SearchPage sp = new SearchPage(_driver);
            sp.MenuIcon();
            Assert.AreEqual("CASTI", sp.getCastiTitle());
       

        }
    }
}
