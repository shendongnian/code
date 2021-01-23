    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 |System.Net.SecurityProtocolType.Tls12;
            using (var service = new ServiceReference2.GatewaySoapClient())
            {
                var result = service.GetFileStatus("bla", "bla", false);
            }
