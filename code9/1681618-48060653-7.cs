    private async Task<bool> UploadChunkToServer(UserCustomFile Chunk)
    {
        var client = new RestClient(Helper.GetServerURL());
        var request = new RestRequest("api/fileupload/savechunk", Method.POST);
        request.AddHeader("Content-type", "application/json");
        request.RequestFormat = RestSharp.DataFormat.Json;
        request.AddJsonBody(Chunk);
        return await client.ExecuteAsync(request, response =>
        {
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.ErrorMessage);
            }
            else
            {
                ChunkStatuses.Add(Chunk.ChunkID);
                return true;
            }
        });
    }
