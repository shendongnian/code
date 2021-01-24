        private HttpClient m_httpClient = new HttpClient();
        private HttpClient MyHttpClient
        {
            get
            {
                if ( m_httpClient==null )
                {
                    m_httpClient = new HttpClient();
                }
                return m_httpClient;
            }
        }
        public async void GetJSON()
        {
            // var client = new HttpClient();
            var client = MyHttpClient;
            // var response = await client.GetAsync("http://192.168.43.226/GetContactsDesert.php");
            // var response = await client.GetAsync(Constants.BaseUrlpos + "GetContactsDesert.php");
            string contactsJson = string.Empty;
            using (HttpResponseMessage response = await client.GetAsync(Constants.BaseUrlpos + "GetContactsDesert.php"))
            { 
                contactsJson = response.Content.ReadAsStringAsync().Result;
            }
            ContectList ObjContactList = new ContectList();
            if (response.IsSuccessStatusCode)
            {
                ObjContactList = JsonConvert.DeserializeObject<ContectList>(contactsJson);
                listviewConactstwo.ItemsSource = ObjContactList.contacts;
            }
            else
            {
                using (var textReader = new JsonTextReader(new StringReader(contactsJson)) )
                {
                    using (dynamic responseJson = new JsonSerializer().Deserialize(textReader))
                    { 
                        contactsJson = "Deserialized JSON error message: " + responseJson.Message;
                    }
                    await DisplayAlert("fail", "no Network Is Available.", "Ok");
                }
            }
            ProgressLoadertwo.IsVisible = false;
        }
