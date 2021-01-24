        Task<string> SendPacket(string url)
        {
            return Task<string>.Factory.StartNew(() =>
            {
                using (var client = new WebClient())
                {
                    NameValueCollection values = new NameValueCollection();
                    values["test"] = "test";
                    // exception occurs at the next line
                    byte[] uploadResponse = client.UploadValues(url, "POST", values);
                    return Encoding.UTF8.GetString(uploadResponse);
                }
            });
        }
        void Main()
        {
            for (int i = 0; i < 5; i++)
            {
                SendPacket("http://localhost:8733/api/values").ContinueWith(task => DoSomethingOnCallback(task.Result));
            }
        }
        void DoSomethingOnCallback(string response)
        {
            Console.WriteLine(response);
        }
