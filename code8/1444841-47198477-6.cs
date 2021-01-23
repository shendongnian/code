    public async Task<RestResult<T>> Post<T>(HttpContent content)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.PostAsync(Endpoint, content);
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    T result = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                    return new RestResult<T> { Result = result, ResultCode = HttpStatusCode.OK };
                }
                RestResult<T> nonOkResult =
                    new RestResult<T> { Result = default(T), ResultCode = response.StatusCode, Message = await response.Content.ReadAsStringAsync() };
                return nonOkResult;
            }
        }
