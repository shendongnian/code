        public static async Task<bool> RequestLicenseManual(PlayReadyLicenseAcquisitionServiceRequest request, params KeyValuePair<string, object>[] headers)
        {
            Debug.WriteLine("ProtectionManager PlayReady Manual License Request in progress");
            try
            {
                var r = request.GenerateManualEnablingChallenge();
                var content = new ByteArrayContent(r.GetMessageBody());
                foreach (var header in r.MessageHeaders.Where(x => x.Value != null))
                {
                    if (header.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                    {
                        content.Headers.ContentType = MediaTypeHeaderValue.Parse(header.Value.ToString());
                    }
                    else
                    {
                        content.Headers.Add(header.Key, header.Value.ToString());
                    }
                }
                var msg = new HttpRequestMessage(HttpMethod.Post, r.Uri) { Content = content };
                foreach (var header in headers)
                {
                    msg.Headers.Add(header.Key, header.Value.ToString());
                }
                Debug.WriteLine("Requesting license from {0} with custom data {1}", msg.RequestUri, await msg.Content.ReadAsStringAsync());
                var client = new HttpClient();
                var response = await client.SendAsync(msg);
                if (response.IsSuccessStatusCode)
                {
                    request.ProcessManualEnablingResponse(await response.Content.ReadAsByteArrayAsync());
                }
                else
                {
                    Debug.WriteLine("ProtectionManager PlayReady License Request failed: " + await response.Content.ReadAsStringAsync());
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ProtectionManager PlayReady License Request failed: " + ex.Message);
                return false;
            }
            Debug.WriteLine("ProtectionManager PlayReady License Request successfull");
            return true;
        }
