        private async Task<IEnumerable<byte[]>> GetAttachmentsAsByteArrayAsync(Activity activity)
        {
            var attachments = activity?.Attachments?
            .Where(attachment => attachment.ContentUrl != null)
            .Select(c => Tuple.Create(c.ContentType, c.ContentUrl));
            if (attachments != null && attachments.Any())
            {
                var contentBytes = new List<byte[]>();
                using (var connectorClient = new ConnectorClient(new Uri(activity.ServiceUrl)))
                {
                    var token = await (connectorClient.Credentials as MicrosoftAppCredentials).GetTokenAsync();
                    foreach (var content in attachments)
                    {
                        var uri = new Uri(content.Item2);
                        using (var httpClient = new HttpClient())
                        {
                            if (uri.Host.EndsWith("skype.com") && uri.Scheme == "https")
                            {
                                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));
                            }
                            else
                            {
                                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(content.Item1));
                            }
                            contentBytes.Add(await httpClient.GetByteArrayAsync(uri));
                        }
                    }
                }
                return contentBytes;
            }
            return null;
        }
