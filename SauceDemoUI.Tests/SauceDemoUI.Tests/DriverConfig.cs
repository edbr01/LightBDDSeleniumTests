using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoUI.Tests
{
    internal static class DriverConfig
    {

        private static IWebDriver _driver;

        public static void Initialize()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string filePath = $"{executableLocation}\\Driver";

            _driver = new ChromeDriver(filePath);
        }

        public static IWebDriver GetDriver()
        {
            return _driver;
        }

        public static void Dispose()
        {
            _driver.Close();
            _driver.Dispose();
        }
    }
}
