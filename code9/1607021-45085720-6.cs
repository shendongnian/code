    public class GoogleNotificationSender {
        private HttpClient client;
        private string authorizationToken;
        public GoogleNotificationSender(string authorizationToken) {
            this.AuthorizationToken = authorizationToken;
        }
        private string AuthorizationToken {
            get { return authorizationToken; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new InvalidOperationException("authorizationToken must not be null");
                authorizationToken = value;
            }
        }
        private HttpClient Client {
            get {
                if (client == null) {
                    client = new HttpClient();
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=" + AuthorizationToken);
                }
                return client;
            }
        }
        public async Task SendAsync(GoogleNotification notification) {
            TracingSystem.TraceInformation("Inside Send Google notification");
            var json = notification.GetJson();
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var requestUri = "https://fcm.googleapis.com/fcm/send";
            using (var message = await Client.PostAsync(requestUri, content)) {
                message.EnsureSuccessStatusCode();
                var result = await message.Content.ReadAsAsync<GoogleNotificationResult>();
                if (result.Failure > 0)
                    throw new Exception($"Sending Failed : {result.Results.FirstOrDefault().Error}");
            }
        }
    }
