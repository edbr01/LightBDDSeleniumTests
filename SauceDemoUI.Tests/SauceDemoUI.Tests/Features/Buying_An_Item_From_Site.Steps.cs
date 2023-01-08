using LightBDD.MsTest2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Threading.Tasks;

namespace SauceDemoUI.Tests.Features
{
    public partial class Buying_An_Item_From_Site : FeatureFixture
    {
        private readonly IWebDriver _driver;

        public Buying_An_Item_From_Site()
        {
            _driver = DriverConfig.GetDriver();
        }

        private Task Given_saucedemo_site_opens()
        {
            _driver.Manage().Window.Maximize();

            //Navigate to Site
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            Thread.Sleep(4000);
            
            return Task.CompletedTask;
        }

        private Task When_user_logins_in()
        {
            //Peform user login

            _driver.FindElement(By.Id("user-name")).SendKeys("standard_user");

            _driver.FindElement(By.Id("password")).SendKeys("secret_sauce");

            Thread.Sleep(4000);

            _driver.FindElement(By.Id("login-button")).Click();

            return Task.CompletedTask;
        }

        private Task Then_adds_item_to_cart()
        {
            //Select Item to buy

            _driver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket")).Click();

            Thread.Sleep(2000);

            return Task.CompletedTask;

        }

        private Task And_selects_cart_and_asserts_item()
        {
            _driver.FindElement(By.XPath("//*[@id='shopping_cart_container']/a")).Click();

            var element = _driver.FindElement(By.XPath("//*[@id='item_5_title_link']/div"));
            Assert.IsTrue(element.Displayed);
            Assert.AreEqual(element.Text.ToLower(), "Sauce Labs Fleece Jacket".ToLower());

            Thread.Sleep(2000);

            return Task.CompletedTask;
        }

        private Task Then_on_checkout_enters_buyers_details()
        {
            //Navigate to checkout

            _driver.FindElement(By.Id("checkout")).Click();

            _driver.FindElement(By.Id("first-name")).SendKeys("John");

            _driver.FindElement(By.Id("last-name")).SendKeys("Doe");

            _driver.FindElement(By.Id("postal-code")).SendKeys("STJ 1089");

            Thread.Sleep(2000);

            return Task.CompletedTask;
        }

        private Task And_on_continue_asserts_totals_details()
        {
            //Assert Totals Before Finalising Order

            _driver.FindElement(By.Id("continue")).Click();

            var elementItemTotal = _driver.FindElement(By.XPath("//*[@id='checkout_summary_container']/div/div[2]/div[5]"));
            Assert.IsTrue(elementItemTotal.Displayed);
            Assert.AreEqual(elementItemTotal.Text.ToLower(), "Item total: $49.99".ToLower());

            var elementTax = _driver.FindElement(By.XPath("//*[@id='checkout_summary_container']/div/div[2]/div[6]"));
            Assert.IsTrue(elementTax.Displayed);
            Assert.AreEqual(elementTax.Text.ToLower(), "Tax: $4.00".ToLower());

            var elementTotal = _driver.FindElement(By.XPath("//*[@id='checkout_summary_container']/div/div[2]/div[7]"));
            Assert.IsTrue(elementTotal.Displayed);
            Assert.AreEqual(elementTotal.Text.ToLower(), "Total: $53.99".ToLower());

            Thread.Sleep(2000);

            return Task.CompletedTask;
        }

        private Task Then_clicks_finish_and_verifies_order_was_dispatched()
        {
            _driver.FindElement(By.Id("finish")).Click();

            var elementDispatch = _driver.FindElement(By.XPath("//*[@id='checkout_complete_container']/div"));
            Assert.IsTrue(elementDispatch.Displayed);
            Assert.AreEqual(elementDispatch.Text.ToLower(), "Your order has been dispatched, and will arrive just as fast as the pony can get there!".ToLower());

            Thread.Sleep(2000);

            return Task.CompletedTask;
        }
    }
}