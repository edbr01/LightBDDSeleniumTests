using LightBDD.MsTest2;
using LightBDD.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UsersAPIService.Tests.Models;
using Newtonsoft.Json.Linq;
using FluentAssertions;

namespace UsersAPIService.Tests.Features
{
    public partial class Retrieving_users
    {
        private readonly HttpClient _client;
        private State<HttpResponseMessage> _response;
        private State<int> _userid;
        private readonly State<User> _expectedUser;

        public Retrieving_users()
        {
            _expectedUser = new User
            {
                Id = 1,
                Name = "Leanne Graham",
                Username = "Bret",
                Email = "Sincere@april.biz",
                Address = new Address
                {
                    Street = "Kulas Light",
                    Suite = "Apt. 556",
                    City = "Gwenborough",
                    Zipcode = "92998-3874",
                    Geo = new Geo
                    {
                        Lat = "-37.3159",
                        Lng = "81.1496"
                    }
                }
                ,
                Phone = "1-770-736-8031 x56442",
                Website = "hildegard.org",
                Company = new Company
                {
                    Name = "Romaguera-Crona",
                    CatchPhrase = "Multi-layered client-server neural-net",
                    Bs = "harness real-time e-markets"
                }
            };

            _client = ClientServer.GetClient();
        }

        private Task Given_an_Id_of_the_created_user()
        {
            _userid = 1;
            return Task.CompletedTask;
        }

        private Task Given_an_Id_of_nonexistent_user()
        {
            _userid = 20;
            return Task.CompletedTask;
        }

        private async Task When_I_request_the_user_by_this_Id()
        {
            _response = await _client.GetUserById(_userid);
        }

        private Task Then_the_response_should_have_status_code(HttpStatusCode code)
        {
            Assert.AreEqual(code, _response.GetValue().StatusCode);
            return Task.CompletedTask;
        }

        private Task Then_the_response_should_contain_existing_user_details()
        {
            var actual = _response.GetValue().DeserializeAsync<User>().Result;

            var expected = _expectedUser.GetValue();

            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Username, actual.Username);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.Address.Street, actual.Address.Street);
            Assert.AreEqual(expected.Address.Suite, actual.Address.Suite);
            Assert.AreEqual(expected.Address.City, actual.Address.City);
            Assert.AreEqual(expected.Address.Zipcode, actual.Address.Zipcode);
            Assert.AreEqual(expected.Address.Geo.Lat, actual.Address.Geo.Lat);
            Assert.AreEqual(expected.Address.Geo.Lng, actual.Address.Geo.Lng);
            Assert.AreEqual(expected.Phone, actual.Phone);
            Assert.AreEqual(expected.Website, actual.Website);
            Assert.AreEqual(expected.Company.Name, actual.Company.Name);
            Assert.AreEqual(expected.Company.CatchPhrase, actual.Company.CatchPhrase);
            Assert.AreEqual(expected.Company.Bs, actual.Company.Bs);

            actual.Name.Should().Be("Leanne Graham");

            return Task.CompletedTask;
        }
    }
}