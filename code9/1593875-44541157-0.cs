    static HttpWebRequest httpWebRequest;
    static void Main()
        {
            httpWebRequest = (HttpWebRequest)WebRequest.Create(SYSTEMSTATUS_SERVER); //
            
            systemStatusTimer = new Timer(500);
            systemStatusTimer.Elapsed += SystemStatusTimer_Elapsed;
            systemStatusTimer.Start();
            
            Console.ReadKey();
        }
    static private void SystemStatusTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.KeepAlive = true;
            httpWebRequest.CookieContainer = cookieContainer;
            httpWebRequest.ServicePoint.SetTcpKeepAlive(true, 100000, 1000);
            Console.WriteLine(cookieContainer);
           
            Console.WriteLine("system Status 100m/s : {0}\t{1}\t{2}", CPU, AVAILABLEHD, AVAILMEMORY);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    cpuusage = CPU,                    
                    availablememory = AVAILMEMORY,
                    availableharddiskspace = AVAILABLEHD
                });
                
                streamWriter.Write(json);
            }
            
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var result_header = httpResponse.Headers;
                Console.WriteLine("The response of sysStatus from server : " + result);              
            }
        }
