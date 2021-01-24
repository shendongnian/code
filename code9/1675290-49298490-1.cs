     string addItemJsonString = "{\"name\":\"Test Visit\"}";
            string requestUrl = "https://graph.microsoft.com/v1.0/sites/{siteID}/lists/{listID}/items/{itemID}/fields";
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(new HttpMethod("PATCH"), requestUrl);
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            //set the request body
            message.Content = new StringContent(addItemJsonString);
            HttpResponseMessage response = await client.SendAsync(message);
            if (response.IsSuccessStatusCode)
            {
                responseString = await response.Content.ReadAsStringAsync();
            }
            else
                responseString = "Error in response";
