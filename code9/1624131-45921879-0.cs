     byte[] rawBytes = ProtoBufSerializer.ProtoSerialize<LoginRequest>(loginRequest);
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-protobuf"));
            
            var byteArrayContent = new ByteArrayContent(rawBytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-protobuf");
            var result = client.PostAsync("Api/Login", byteArrayContent).Result;
