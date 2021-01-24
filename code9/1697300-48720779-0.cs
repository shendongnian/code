        class Program
    {
        static void Main(string[] args)
        {
            string resend ;
            do
            {
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var objNotification = new
                {
                    to = "Token the device you want to push notification to",
                    data = new
                    {
                        title = "title",
                        body = "body",
                        icon = "/firebase-logo.png"
                    }
                };
                string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(objNotification);
                Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", "your authorization key"));
                tRequest.Headers.Add(string.Format("Sender: id={0}", "your senderId"));
                tRequest.ContentLength = byteArray.Length;
                tRequest.ContentType = "application/json";
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String responseFromFirebaseServer = tReader.ReadToEnd();
                                FCMResponse response = Newtonsoft.Json.JsonConvert.DeserializeObject<FCMResponse>(responseFromFirebaseServer);
                                if (response.success == 1)
                                {
                                    Console.WriteLine("succeeded");
                                }
                                else if (response.failure == 1)
                                {
                                   Console.WriteLine("failed");
                                }
                            }
                        }
                    }
                }
                resend = Console.ReadLine();
            } while (resend == "c");
        }
    }
    public class FCMResponse
    {
        public long multicast_id { get; set; }
        public int success { get; set; }
        public int failure { get; set; }
        public int canonical_ids { get; set; }
        public List<FCMResult> results { get; set; }
    }
    public class FCMResult
    {
        public string message_id { get; set; }
    }
