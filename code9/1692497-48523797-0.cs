                var upfilebytes = DependencyService.Get<ILocalFileProvider>().GetFileBytes(FileUrl);
                MultipartFormDataContent content = new MultipartFormDataContent();
                ByteArrayContent baContent = new ByteArrayContent(upfilebytes);
                content.Add(baContent, "File", "attachment.png");
                var response = await client.PostAsync(url, content);
