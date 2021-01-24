    async Task<JObject> GetJObjectFromFormData()
        {
            using (Stream strea = new MemoryStream())
            {
                Request.InputStream.Position = 0;
                await Request.InputStream.CopyToAsync(strea);
                strea.Position = 0;
                using (StreamReader reader = new StreamReader(strea))
                {
                    var req = reader.ReadToEnd();
                    return !string.IsNullOrEmpty(req) ? JObject.Parse(req) : null;
                }
            }
        }
