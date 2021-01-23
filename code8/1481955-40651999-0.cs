        public static async void GetPerson()
        {
            //System.Diagnostics.Debug.WriteLine("NetworkConnectivityLevel.InternetAccess: " + NetworkConnectivityLevel.InternetAccess);
            //use this, for checking the network connectivity
            System.Diagnostics.Debug.WriteLine("GetIsNetworkAvailable: " + System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable());
            //var msg = new Windows.UI.Popups.MessageDialog("GetIsNetworkAvailable: " + System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable());
            //msg.ShowAsync();
            HttpClient httpClient = new HttpClient();
            // Assign the authentication headers
            httpClient.DefaultRequestHeaders.Authorization = CreateBasicHeader("MYUSERNAME", "MYPASS");
            System.Diagnostics.Debug.WriteLine("httpClient.DefaultRequestHeaders.Authorization: " + httpClient.DefaultRequestHeaders.Authorization);
            // Call out to the site
            HttpResponseMessage response = await httpClient.GetAsync("https://api.fos.be/person/login.json?login=usern&password=pass");
            System.Diagnostics.Debug.WriteLine("response: " + response);
            string responseAsString = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine("response string:" + responseAsString);
        }
        public static AuthenticationHeaderValue CreateBasicHeader(string username, string password)
        {
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(username + ":" + password);
            String logindata = (username + ":" + password);
            System.Diagnostics.Debug.WriteLine("AuthenticationHeaderValue: " + new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray)));
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }
