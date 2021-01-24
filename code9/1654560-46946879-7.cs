                [Fact]
                public void Test1()
                {
                    var envVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");&#xD;
                    Console.WriteLine($"env: {envVariable}");
                    var config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                         .AddJsonFile($"appsettings.{envVariable}.json", optional: true)
                        .Build();
                    var conn = config.GetConnectionString("BloggingDatabase");
                    var otherSettings = config["OtherSettings:UserName"];
                    Console.WriteLine(conn);
                    Console.WriteLine(otherSettings);
                }
