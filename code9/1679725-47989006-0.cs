    string path = "sdcard/testaudio.3gpp";
    
                    var content = new MultipartFormDataContent();
                    var audioContent = new ByteArraycontent(System.IO.File.ReadAllBytes(path));
                    audioContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/3gpp");
                    content.Add(audioContent, "audio", "testaudio.3gpp");
                    var httpClient = new HttpClient();
    
                    var uploadServiceBaseAddress = "https://example.com/UploadaudioFile.aspx";
    
    
                    var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);
    
                    string resp = await httpResponseMessage.Content.ReadAsStringAsync();
