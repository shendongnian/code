    namespace MatrixGuide
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                // Read .ini file and overtake the contend in globale
                // Do it in an try-catch to be able to react to errors
                GV.bFehler_Ini = false;
                try
                {
                    var iniconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddIniFile("matrixGuide.ini", optional: false, reloadOnChange: true)
                    .Build();
                    string cURL = iniconfig.GetValue<string>("Startup:URL");
                    bool bdummy1 = iniconfig.GetValue<bool>("Parameter:Dummy1");
                    int idummy2 = iniconfig.GetValue<int>("Parameter:Dummy2");
                    //
                    GV.cURL = cURL;
                    GV.bdummy1 = bdummy1;
                    GV.idummy1 = idummy2;
                }
                catch (Exception e)
                {
                    GV.bFehler_Ini = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!! Fehler beim Lesen von MatrixGuide.ini !!");
                    Console.WriteLine("Message:" + e.Message);
                    if (!(e.InnerException != null))
                    {
                        Console.WriteLine("InnerException: " + e.InnerException.ToString());
                    }
    
                    Console.ForegroundColor = ConsoleColor.White;
                }
                // End .ini file processing
                //
                CreateWebHostBuilder(args).Build().Run();
            }
    
            public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>() //;
                .UseUrls(GV.cURL, "http://localhost:5000"); // set the to use URL from .ini -> no impact to IISExpress
    
        }
    }
