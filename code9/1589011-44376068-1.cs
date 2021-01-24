    public async Task<UserAccount> SaveProduct(UserAccount product)
    {
        try { 
            using (var client = new HttpClient ()) {
                client.BaseAddress = new Uri ("http://blabla:80/test/");
                client.DefaultRequestHeaders.Accept.Clear ();
                client.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/json"));
                var uri = new Uri ("http://blabla:80/test/api/Users/save");
                string serializedObject = JsonConvert.SerializeObject (product);
                HttpContent contentPost = new StringContent (serializedObject, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync (uri, contentPost);
                if (response.IsSuccessStatusCode) {
                    var data = await response.Content.ReadAsStringAsync ();
                    UserAccount product = JsonConvert.DeserializeObject<UserAccount>(data);
                    return product;
                }
            }
        }
        catch (Exception) {
            return null;
        }
    }
