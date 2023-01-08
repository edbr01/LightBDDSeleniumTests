using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UsersAPIService.Tests
{
    internal static class UserApiExtensions
    {
        public static Task<HttpResponseMessage> GetUserById(this HttpClient client, int id)
        {
            return client.GetAsync($"users/{id}");
        }
    }
}