    public async Task<CreateImageResult> CreateImagesFromData(byte[] _image)
    {
        HttpContent bytesContent = new ByteArrayContent(_image);
    
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Training-key", _trainingKey);
    
            HttpResponseMessage response;
    
            using (var content = new MultipartFormDataContent())
            {
                content.Add(bytesContent, "Image", "Image");
                response = await client.PostAsync(String.Format("Training/projects/{0}/images/image?tagIds=Default", _projectId), content);
            }
    
            HttpContent data = response.Content;
            string result = await data.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateImageResult>(result);
        }
    }
