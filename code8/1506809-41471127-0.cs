    public async Task<string> GetImageInsights(byte[] image)
    {
        var uri = "https://api.cognitive.microsoft.com/bing/v5.0/images/search?modulesRequested=similarimages";
    
        var response = await RequestHelper.MakePostRequest(uri, image, key);
    
        var respString = await response.Content.ReadAsStringAsync();
    
        return respString;
    }
    
    class RequestHelper
    { 
        public static async Task<HttpResponseMessage> MakePostRequest(String uri, byte[] imageData, string key)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
    
                var content = new MultipartFormDataContent();
                content.Add(new ByteArrayContent(imageData), "image", "image.png");
    
                return await client.PostAsync(uri, content);
            }
        }
    }
