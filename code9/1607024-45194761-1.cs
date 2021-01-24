        public Task Send(GoogleNotification notification)
        {
            return Task.Run(()=>
            {
                TracingSystem.TraceInformation("Inside Send Google notification");
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=" + AuthorizationToken);
                    string json = notification.GetJson();
                    StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    using (HttpResponseMessage message =client.PostAsync("https://fcm.googleapis.com/fcm/send", content).Result)
                    {
                        message.EnsureSuccessStatusCode();
                        string resultAsString = message.Content.ReadAsStringAsync().Result;
                        GoogleNotificationResult result = JsonConvert.DeserializeObject<GoogleNotificationResult>(resultAsString);
                        if (result.Failure > 0)
                            throw new Exception($"Sending Failed : {result.Results.FirstOrDefault().Error}");
                    }
                }
            });
        }
