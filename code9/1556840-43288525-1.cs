        Uri tokenUri = new Uri(@"https://localhost:55970/Token");
        // This is a test data set from my Web Api pulling data from 
        // Entity Framework and SQL Server protected by the Authorize attribute
        Uri testCasesUri = new Uri(@"https://localhost:55970/api/Cases");
        string accessToken = "";
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void btn_SubmitLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txt_User.Text;
            string password = txt_Password.Password;
            HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.InvalidName);
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.RevocationFailure);
            HttpClient client = new HttpClient(filter);
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("client_id", "web");
            parameters.Add("grant_type", "password");
            parameters.Add("username", username);
            parameters.Add("password", password);
            try
            {
                HttpResponseMessage result = await client.PostAsync(tokenUri, new HttpFormUrlEncodedContent(parameters));
                string jsonResult = await result.Content.ReadAsStringAsync();
                // TokenResult is a custom model class for deserialization of the Token Endpoint
                // Be sure to include Newtonsoft.Json from NuGet
                var resultObject = JsonConvert.DeserializeObject<TokenResult>(jsonResult);
                accessToken = resultObject.AccessToken;
                // When setting the request for data from Web Api set the Authorization
                // header to Bearer and the token you retrieved
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                result = await client.GetAsync(testCasesUri);
                jsonResult = await result.Content.ReadAsStringAsync();
            } catch(Exception ex)
            {
                string debugBreak = ex.ToString();
            }
