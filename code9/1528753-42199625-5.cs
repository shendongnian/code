            TRSULT HttpPostRequest<TREQ, TRSULT>(string requestUrl, TREQ requestObject)
        {
            using (var client = new HttpClient())
            {
                // you should replace wiht your api key
                client.DefaultRequestHeaders.Add("X-WorkWave-Key", "YOUR API KEY");
                client.BaseAddress = new Uri("wrm.workwave.com");
                using (var responseMessage = client.PostAsJsonAsync <TREQ>(requestUrl, requestObject).Result)
                {
                    TRSULT result = responseMessage.Content.ReadAsAsync<TRSULT>().Result;
                    return result;
                }
            }
        }
    
