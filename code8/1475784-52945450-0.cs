    namespace BasicApp
    {
        public class Startup
        {
            public void Configure(IApplicationBuilder app)
            {
                var allowedIPs =
                    new List<IPAddress>
                        {
                            IPAddress.Parse("10.20.30.40"),
                            IPAddress.Parse("1.2.3.4"),
                            IPAddress.Parse("5.6.7.8")
                        };
    
                var allowedCIDRs =
                    new List<CIDRNotation>
                        {
                            CIDRNotation.Parse("110.40.88.12/28"),
                            CIDRNotation.Parse("88.77.99.11/8")
                        };
    
                app.UseFirewall(
                    FirewallRulesEngine
                        .DenyAllAccess()
                        .ExceptFromIPAddressRanges(allowedCIDRs)
                        .ExceptFromIPAddresses(allowedIPs));
    
                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            }
        }
    }
