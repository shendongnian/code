    //Start and configure server 1.
    IWebHostBuilder server1 = new WebHostBuilder()
     .UseStartup < Project1.Startup > ()
     .UseKestrel(options => options.Listen(IPAddress.Any, 80))
     .UseConfiguration(new ConfigurationBuilder()
      .AddJsonFile("appsettings_server1.json")
      .Build()
     );
    
    TestServer testServer1 = new TestServer(server1);
    
    //Get HttpClient that's able to connect to server 1.
    HttpClient client1 = server1.CreateClient();
    
    IWebHostBuilder _server2 = new WebHostBuilder()
     .UseStartup < Project2.Startup > ()
     .ConfigureTestServices(
      services => {
       //Inject HttpClient that's able to connect to server 1.
       services.AddSingleton(typeof(HttpClient), client1);
      })
     .UseKestrel(options => options.Listen(IPAddress.Any, 81))
     .UseConfiguration(new ConfigurationBuilder()
      .AddJsonFile("appsettings_server2.json")
      .Build()
     );
    
    TestServer testServer2 = new TestServer(server2);
