      static async Task<string> HttpGetResponse()
        {
            WebRequest request = WebRequest.Create("some_url");
            request.Headers.Add("cookie", "some_cookie");
            string responseData;
            Stream objStream = request.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);
            string sLine = "";
            int i = 0;
            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                    Console.WriteLine(sLine);
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("cookie", "some_cookie");
                using (var response = await client.GetAsync("some_url"))
                {
                    responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseData);
                }
            }
            return responseData;
        }
