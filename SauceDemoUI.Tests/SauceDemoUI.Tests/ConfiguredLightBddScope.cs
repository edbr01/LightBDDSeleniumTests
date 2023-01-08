using LightBDD.Core.Configuration;
using LightBDD.MsTest2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]

namespace SauceDemoUI.Tests
{
    [TestClass]
    public class ConfiguredLightBddScope
    {        

        [AssemblyInitialize]
        public static void Setup(TestContext testContext)
        {
            LightBddScope.Initialize(OnConfigure);

            DriverConfig.Initialize();
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            LightBddScope.Cleanup();
            DriverConfig.Dispose();
        }

        private static void OnConfigure(LightBddConfiguration configuration)
        {
            // LightBDD configuration
        }
    }
}
