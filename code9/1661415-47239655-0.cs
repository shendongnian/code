     public async Task<object> GetMediaInfo(string mediaId)
            {
                string clientId = "YOUR_CLIENT_ID";
    			string clientSecret = "YOUR_CLIENT_SECRET";
                string accessToken = "A_VALID_ACCESS_TOKEN";
                InstagramClient client = new InstagramClient(clientId,clientSecret);
                var media = await client.MediaEndpoints.GetMediaInfoAsync(mediaId, accessToken);
                //I use Json.NET for parsing the result
                var mediaJson = JsonConvert.DeserializeObject(media);
                //You can deserialize json result to one of the models in InstagramCSharp or to your custom model
                //var mediaJson = JsonConvert.DeserializeObject<Envelope<Media>>(mediaJson);
    
                return mediaJson;
            }   
    	}
