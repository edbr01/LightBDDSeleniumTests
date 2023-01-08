using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAPIService.Tests.Models
{
    public class ConfigurationSettings
    {
        public string CurrentEnvironment { get; set; }
        public List<URL> URLS { get; set; }
    }

    public class URL
    {
        public string BaseAddressEnv { get; set; }
        public string Url { get; set; }
    }
}