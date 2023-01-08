using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.MsTest2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace SauceDemoUI.Tests.Features
{
    [Label("FEAT-1 -  Buying an Item From Site")]
    [FeatureDescription(
    @"In order to verify Website Functionality
    As a user
    I want to be able to login in, select an item to purchase and buy item.")]
    [TestClass]
    public partial class Buying_An_Item_From_Site
    {
        [Label("SCENARIO-1 - Buying An Item From Site")]
        [Scenario]
        public Task Buying_an_Item_From_Site()
        {
             Runner.RunScenario(
                _ => Given_saucedemo_site_opens(),
                _ => When_user_logins_in(),
                _ => Then_adds_item_to_cart(),
                _ => And_selects_cart_and_asserts_item(),
                _ => Then_on_checkout_enters_buyers_details(),
                _ => And_on_continue_asserts_totals_details(),
                _ => Then_clicks_finish_and_verifies_order_was_dispatched());

            return Task.CompletedTask;
        }
        
    }
}