using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Reflection;
using UsersAPIService.Tests.Models;

namespace UsersAPIService.Tests
{
    internal static class ClientServer
    {
        public static HttpClient _client;

        public static ConfigurationSettings _config;

        public static void Initialize()
        {
            LoadMappingsFromPath();

            _client = new HttpClient();

            string url = _config.URLS.Find(e => e.BaseAddressEnv == _config.CurrentEnvironment).Url;

            _client.BaseAddress = new Uri(url);
        }

        public static HttpClient GetClient()
        {
            return _client;
        }

        public static void Dispose()
        {
            _client.Dispose();
        }

        private static void LoadMappingsFromPath()
        {
            string executableLocation = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location);

            string filePath = $"{executableLocation}\\Config\\config.json";

            string json = File.ReadAllText(filePath);

            _config = JsonSerializer.Deserialize<ConfigurationSettings>(json);
        }
    }
}