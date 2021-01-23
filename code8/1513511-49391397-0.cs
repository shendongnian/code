    MultipartFormDataContent  lContent=new MultipartFormDataContent();
    byte[]  lBytes = DependencyService.Get<IFileHelper>().ReadAllBytes(filename);
    ByteArrayContent lFileContent= new ByteArrayContent(lBytes);
    lFileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                                                {
                                                    FileName = filename,
                                                    Name = "imgFile"
                                                };
    lFileContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");
    lContent.Add(lFileContent);
    HttpResponseMessage lRequestResponse=await lHttpClient.PostAsync(await url, lContent);
