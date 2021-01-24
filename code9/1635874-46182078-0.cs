    static void Main(string[] args)
            {
                Transcribe();
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
    
            // http://www.ibm.com/smarterplanet/us/en/ibmwatson/developercloud/doc/getting_started/gs-credentials.shtml
            static String username = "<username>";
            static String password = "<password>";
    
            static String file = @"c:\audio.wav";
    
            static Uri url = new Uri("wss://stream.watsonplatform.net/speech-to-text/api/v1/recognize");
            
            // these should probably be private classes that use DataContractJsonSerializer 
            // see https://msdn.microsoft.com/en-us/library/bb412179%28v=vs.110%29.aspx
            // or the ServiceState class at the end
            static ArraySegment<byte> openingMessage = new ArraySegment<byte>( Encoding.UTF8.GetBytes(
                "{\"action\": \"start\", \"content-type\": \"audio/wav\", \"continuous\" : true, \"interim_results\": true}"
            ));
            static ArraySegment<byte> closingMessage = new ArraySegment<byte>(Encoding.UTF8.GetBytes(
                "{\"action\": \"stop\"}"
            ));
            // ... more in the link below
