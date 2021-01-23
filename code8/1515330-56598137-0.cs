    public string UploadFile(ZendeskFile file)
    {
        try
        {
            var request = new RestRequest(FileUploadsPath, Method.POST);
            request.AddQueryParameter("filename", file.Name);
            request.AddParameter("application/binary", file.Data, ParameterType.RequestBody);
            var response = Execute<UploadZendeskFileResponse>(request);
            var result = JsonConvert.DeserializeObject<UploadZendeskFileResponse>(response.Content);
            return result.upload.token;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
