      private string TestURL = "http://beresun.ir/API/";
        string token = "2JEuksuv86DcFmLrQa7nna4QDeowuGTqpyUK0pf9wSlbe6D5hLtEVxvzMT5gAZG0xBKy00HxS3J79mcr8F54dBD0uIg5HX5fzPOAP";
        int restaurant_id = 1;
        int admin_id = 2;
        int token_id = 40;
        public async Task<string> test()
        {
            try
            {
                using (var Client = new HttpClient())
                {
                    Client.BaseAddress = new Uri(TestURL);
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    string postData = "token=" + token +
                    "&restaurant_id=" + restaurant_id +
                    "&admin_id=" + admin_id +
                    "&token_id=" + token_id;
                    HttpResponseMessage responce = await Client.GetAsync("Orders/0?" + postData);
                    if (responce.IsSuccessStatusCode)
                    {
                        var Json = await responce.Content.ReadAsStringAsync();
                        //  !
                        return Json;
                    }
                    else
                    {
                        // deal with error or here ...
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
