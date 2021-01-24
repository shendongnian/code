    //Passing parameters - AuthenticationResult, URI with authentication header, List of categories.
    public string UpdateCategory(AuthenticationResult result, string uriString,List<string> categories)
        {
            //HTTPMethod.PATCH not available so adding it manualy.
            var httpMethod = new HttpMethod("PATCH");
            HttpRequestMessage request = new HttpRequestMessage(httpMethod, uriString);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
            ChangeEmailCategory cec = new ChangeEmailCategory();
            cec.Categories = categories;
            //Serializing class properties as JSON
            var jsonData = JsonConvert.SerializeObject(cec);
            //Adding JSON to request body
            request.Content =new StringContent(jsonData,Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.SendAsync(request).Result;
            if (!response.IsSuccessStatusCode)
                throw new WebException(response.StatusCode.ToString() + ": " + response.ReasonPhrase);
            return response.Content.ReadAsStringAsync().Result;
        }
