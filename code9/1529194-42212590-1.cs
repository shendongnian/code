            using (var httpClient = new HttpClient())
            {
                var surveyBytes = ConvertToByteArray(surveyResponse);
                httpClient.DefaultRequestHeaders.Add("X-API-TOKEN", _apiToken);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var byteArrayContent =   new ByteArrayContent(surveyBytes);
                byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("text/csv");
                var response = await httpClient.PostAsync(_importUrl, new MultipartFormDataContent
                {
                    {new StringContent(surveyId), "\"surveyId\""},
                    {byteArrayContent, "\"file\"", "\"feedback.csv\""}
                });
                return response;
            }
