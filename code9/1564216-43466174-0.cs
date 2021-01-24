            var c = new IgniteConfiguration
            {
                Localhost = "127.0.0.1",
                DiscoverySpi = new TcpDiscoverySpi
                {
                    IpFinder = new TcpDiscoveryStaticIpFinder
                    {
                        Endpoints = new[] {"127.0.0.1:47500"}
                    },
                }
            };
