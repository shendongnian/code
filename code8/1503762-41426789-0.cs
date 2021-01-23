    protected async Task<CQ> preformRequest(string path, FileParamter file, Dictionary<int, Exception> exceptions = null, Dictionary<String, String> headers = null, string dispositionType = "file")
            {
                if (!checkUrl(path))
                {
                    throw new ArgumentException("Not a valid url.");
                }
    
                MultipartFormDataContent multiPartContent = new MultipartFormDataContent();
    
                this.addHeaders(headers);
    
                ByteArrayContent fileContent = new ByteArrayContent(file.File);
    
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue(dispositionType)
                {
                    FileName = file.FileName,
                    Name = dispositionType,
                    DispositionType = "form-data"
                };
    
                multiPartContent.Add(fileContent);
    
                var task = Client.PostAsync(path, multiPartContent)
                   .ContinueWith(tsk =>
                   {
                       HttpStatusCode code = tsk.Result.StatusCode;
    
                       if (!this.isStatusCodeSuccess(code))
                       {
                           this.handleStatusCodes(code, exceptions);
                       }
    
                       return tsk.Result.Content.ReadAsStringAsync();
                   });
    
    
                return await Task.Factory.StartNew(() => CQ.Create(task.Unwrap().Result));
            }
