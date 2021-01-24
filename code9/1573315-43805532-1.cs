    public async Task<string> SaveUserItemAsync(User item, bool isNewItem = false)
            {
                try
                {
                    var RestUrl = "http://192.168.240.127:55642/RestServiceImpl.svc/UploadUser/{0}/{1}";
    
                    var uri = new Uri(string.Format(RestUrl, item.Id, item.Name));
                    UploadObject obj = new UploadObject();
                    obj.image = item.Thumbnail;
    
                    var json = JsonConvert.SerializeObject(obj);
                    var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
    
                    var content = new StreamContent(stream);
                    content.Headers.ContentLength = stream.Length;
    
                    if (isNewItem)
                    {
                       
                        var response = await client.PostAsync(uri, content).ConfigureAwait(false);
                        if (response.IsSuccessStatusCode)
                        {
                            var res = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            return res;                       
                        }
                       
                        return "success";
                    }
                   
                }
                catch (Exception ex)
                {
                    
                }
                return "Failure";
            }
