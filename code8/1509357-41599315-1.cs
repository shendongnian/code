            var client = new System.Net.Http.HttpClient { BaseAddress = new Uri("http://localhost:5002") };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-protobuf"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("api/home");
            if (response.IsSuccessStatusCode)
            {   
                if (response.Content.Headers.ContentType.MediaType == "application/x-protobuf")
                {             
                    using(var stream = await response.Content.ReadAsStreamAsync())
                    {
                        var protoBufModel = ProtoBuf.Serializer.Deserialize<ProtobufModelDto>(stream);
                        return $"{protoBufModel.Name}, {protoBufModel.StringValue}, {protoBufModel.Id}";
                    }
                }
                var content = await response.Content.ReadAsStringAsync();
                var jsonModel = JsonConvert.DeserializeObject<ProtobufModelDto>(content);
                return $"{jsonModel.Name}, {jsonModel.StringValue}, {jsonModel.Id}";
            }
            return "Failed";
