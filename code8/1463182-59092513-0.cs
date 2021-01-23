    public static void Main(string[] args)
            {
                var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
                string env="", sbj="", crtf = "";
    
                try
                {
                    var whb = WebHost.CreateDefaultBuilder(args).UseContentRoot(Directory.GetCurrentDirectory());
    
                    var environment = env = whb.GetSetting("environment");
                    var subjectName = sbj = CertificateHelper.GetCertificateSubjectNameBasedOnEnvironment(environment);
                    var certificate = CertificateHelper.GetServiceCertificate(subjectName);
                    
                    crtf = certificate != null ? certificate.Subject : "It will after the certification";
    
                    if (certificate == null) // present apies even without server certificate but dont give permission on authorization
                    {
                        var host = whb
                            .ConfigureKestrel(_ => { })
                            .UseContentRoot(Directory.GetCurrentDirectory())
                            .UseIISIntegration()
                            .UseStartup<Startup>()
                            .UseConfiguration(configuration)
                            .UseSerilog((context, config) =>
                            {
                                config.ReadFrom.Configuration(context.Configuration);
                            })
                            .Build();
                        host.Run();
                    }
                    else
                    {
                        var host = whb
                            .ConfigureKestrel(options =>
                            {
                                options.Listen(new IPEndPoint(IPAddress.Loopback, 443), listenOptions =>
                                {
                                    var httpsConnectionAdapterOptions = new HttpsConnectionAdapterOptions()
                                    {
                                        ClientCertificateMode = ClientCertificateMode.AllowCertificate,
                                        SslProtocols = System.Security.Authentication.SslProtocols.Tls12,
                                        ServerCertificate = certificate
                                    };
                                    listenOptions.UseHttps(httpsConnectionAdapterOptions);
                                });
                            })
                            .UseContentRoot(Directory.GetCurrentDirectory())
                            .UseIISIntegration()
                            .UseUrls("https://*:443")
                            .UseStartup<Startup>()
                            .UseConfiguration(configuration)
                            .UseSerilog((context, config) =>
                            {
                                config.ReadFrom.Configuration(context.Configuration);
                            })
                            .Build();
                        host.Run();
                    }
    
    
    
                    Log.Logger.Information("Information: Environment = " + env +
                        " Subject = " + sbj +
                        " Certificate Subject = " + crtf);
    
                }
                catch(Exception ex)
                {
                    Log.Logger.Error("Main handled an exception: Environment = " + env +
                        " Subject = " + sbj +
                        " Certificate Subject = " + crtf +
                        " Exception Detail = " + ex.Message);
                }
            }
