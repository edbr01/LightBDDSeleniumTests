using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.MsTest2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;

namespace UsersAPIService.Tests.Features
{
    [Label("FEAT 1 - User Retrieval")]
    [FeatureDescription(
    @"In order to manage users
    As an api service
    I want to be able to retrieve exisitng users")]
    [TestClass]
    public partial class Retrieving_users : FeatureFixture
    {
        [Label("SCENARIO 1 - Retrieve User by ID")]
        [Scenario]
        public async Task Retrieving_user_by_Id()
        {
            await Runner.RunScenarioAsync(
                _ => Given_an_Id_of_the_created_user(),
                _ => When_I_request_the_user_by_this_Id(),
                _ => Then_the_response_should_have_status_code(HttpStatusCode.OK),
                _ => Then_the_response_should_contain_existing_user_details());
        }

        [Label("SCENARIO 2 - Retrieve Non Existent User by ID")]
        [Scenario]
        public async Task Retrieving_nonexistent_user()
        {
            await Runner.RunScenarioAsync(
                 _ => Given_an_Id_of_nonexistent_user(),
                 _ => When_I_request_the_user_by_this_Id(),
                 _ => Then_the_response_should_have_status_code(HttpStatusCode.NotFound));
        }
    }
}