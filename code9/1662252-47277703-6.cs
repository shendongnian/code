    static void Main(string[] args)
    {   
        //send the message
        var wc = new WebClient();
        wc.Headers["Authorization"] = createToken("https://brucesb.servicebus.windows.net/order", "RootManageSharedAccessKey", "{your-key}");
        var messageBody = JsonConvert.SerializeObject(new DemoMessage() { Title = "hello world!!!!" }, Newtonsoft.Json.Formatting.Indented);
        wc.UploadString("https://brucesb.servicebus.windows.net/order/messages", "POST", messageBody);
        
        //receive the message
        QueueClient client = QueueClient.CreateFromConnectionString(connectionString, "order");
        client.OnMessage(message =>
        {
            using (var stream = message.GetBody<Stream>())
            {
                using (var streamReader = new StreamReader(stream, Encoding.UTF8))
                {
                    var msg = streamReader.ReadToEnd();
                    var obj = JsonConvert.DeserializeObject<DemoMessage>(msg);
                    Console.WriteLine(msg);
                }
            }
        });
        Console.WriteLine("Press any key to exit...");
        Console.ReadLine();
    }
    static string createToken(string resourceUri, string keyName, string key)
    {
        var expiry = (long)(DateTime.UtcNow.AddDays(1) - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        string stringToSign = HttpUtility.UrlEncode(resourceUri) + "\n" + expiry;
        HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
        var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
        var sasToken = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}", HttpUtility.UrlEncode(resourceUri), HttpUtility.UrlEncode(signature), expiry, keyName);
        return sasToken;
    }
