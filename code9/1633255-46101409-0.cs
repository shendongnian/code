        private async Task UploadToBlobAsync(string blobName, Stream source, string iothubnamespace, string deviceId, string deviceKey)
        {
            using(HttpClient client = new HttpClient())
            {
                // create authorization header
                string deviceSasToken = GetSASToken($"{iothubnamespace}.azure-devices.net/devices/{deviceId}", deviceKey, null, 1);
                client.DefaultRequestHeaders.Add("Authorization", deviceSasToken);
                // step 1. get the upload info
                var payload = JsonConvert.SerializeObject(new { blobName = blobName }); 
                var response = await client.PostAsync($"https://{iothubnamespace}.azure-devices.net/devices/{deviceId}/files?api-version=2016-11-14", new StringContent(payload, Encoding.UTF8, "application/json"));                
                var infoType = new { correlationId = "", hostName = "", containerName = "", blobName = "", sasToken = "" };
                var uploadInfo = JsonConvert.DeserializeAnonymousType(await response.Content.ReadAsStringAsync(), infoType);
                // step 2. upload blob
                var uploadUri = $"https://{uploadInfo.hostName}/{uploadInfo.containerName}/{uploadInfo.blobName}{uploadInfo.sasToken}";
                client.DefaultRequestHeaders.Add("x-ms-blob-type", "blockblob");
                client.DefaultRequestHeaders.Remove("Authorization");
                response = await client.PutAsync(uploadUri, new StreamContent(source));
                // step 3. send completed
                bool isUploaded = response.StatusCode == System.Net.HttpStatusCode.Created;
                client.DefaultRequestHeaders.Add("Authorization", deviceSasToken);
                payload = JsonConvert.SerializeObject(new { correlationId = uploadInfo.correlationId, statusCode = isUploaded ? 0 : -1, statusDescription = response.ReasonPhrase, isSuccess = isUploaded });
                response = await client.PostAsync($"https://{iothubnamespace}.azure-devices.net/devices/{deviceId}/files/notifications?api-version=2016-11-14", new StringContent(payload, Encoding.UTF8, "application/json"));
            }
        }
   
