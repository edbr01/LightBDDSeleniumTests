using LightBDD.Core.Configuration;
using LightBDD.MsTest2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UsersAPIService.Tests;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]

namespace UsersAPIService.Tests
{
    [TestClass]
    internal class ConfiguredLightBddScopeAttribute
    {
        [AssemblyInitialize]
        public static void Setup(TestContext testContext)
        {
            LightBddScope.Initialize(OnConfigure);

            ClientServer.Initialize();
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            LightBddScope.Cleanup();
            ClientServer.Dispose();
            // code executed after all scenarios
        }

        private static void OnConfigure(LightBddConfiguration configuration)
        {
            // LightBDD configuration
        }
    }
}