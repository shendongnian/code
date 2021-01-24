    using System.Linq;
    using System.Net.NetworkInformation;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    namespace WebApplication1.Controllers
    {
        public class HomeController : Controller
        {
            public IActionResult GetInterfaceInfo()
            {
                var connectionLocalAddress = HttpContext.Connection.LocalIpAddress;
                var connectionLocalInterface = NetworkInterface.GetAllNetworkInterfaces()
                    .Where(iface => iface.GetIPProperties().UnicastAddresses.Any(unicastInfo => unicastInfo.Address.Equals(connectionLocalAddress)))
                    .SingleOrDefault();
                var results = new {
                    NetworkInterface = connectionLocalInterface,
                    IPInterfaceProperties = connectionLocalInterface?.GetIPProperties(),
                    IPInterfaceStatistics = connectionLocalInterface?.GetIPStatistics(),
                    IPv4InterfaceStatistics = connectionLocalInterface?.GetIPv4Statistics()
                };
                return Json(
                    results,
                    new JsonSerializerSettings() {
                        ContractResolver = new IgnorePropertyExceptionsResolver(),
                        Formatting = Formatting.Indented
                    }
                );
            }
        }
    }
