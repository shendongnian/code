        async private void Btn_Clicked(object sender, System.EventArgs e)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetAsync(@"http://uri/HttpClientPostWebService/Api/Swipes?locationId=1&userId=2&ebCounter=3&dateTimeTicks=4&swipeDirection=5&serverTime=6");
                var content = await result.Content.ReadAsStringAsync();
                var resp = JsonConvert.DeserializeObject<SwipeResponse>(content);
            }
            catch (Exception ex)
            {
            }
            try
            {
                var result1 = await client.PostAsync(@"http://uri/HttpClientPostWebService/Api/Swipes",
                    new StringContent(JsonConvert.SerializeObject(new SwipeRequest() { TestIntRequest = 5, TestStringRequest = "request" }), Encoding.UTF8, "application/json"));
                var content1 = await result1.Content.ReadAsStringAsync();
                var resp1 = JsonConvert.DeserializeObject<SwipeResponse>(content1);
            }
            catch (Exception ex)
            {
            }
        }
