    /// <summary>
    /// Deep insert parent and child.
    /// </summary>
    /// <param name="parentEntityPluralName"></param>
    /// <param name="entity"></param>
    public TEntity SaveWithChildren<TEntity>(string parentEntityPluralName, TEntity entity) where TEntity : BaseEntityType
    {
        // need to serialize the entity so that we can send parent and child together
        string serializedEntity = Newtonsoft.Json.JsonConvert.SerializeObject(entity, new Newtonsoft.Json.JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
        // create a handler for the httpclient
        using (System.Net.Http.HttpClientHandler httpHandler = new System.Net.Http.HttpClientHandler())
        {
            // create the httpclient and add the handler
            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient(httpHandler))
            {
                // setup the headers
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Prefer", @"odata.include-annotations=""*""");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json;odata.metadata=minimal");
                // setup the content to send
                using (System.Net.Http.StringContent odataContent = new System.Net.Http.StringContent(serializedEntity))
                {
                    // setup the content type to json
                    odataContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    // post the data to the odata service
                    using (System.Net.Http.HttpResponseMessage response = httpClient.PostAsync(this.BaseUri + parentEntityPluralName, odataContent).Result)
                    {
                        // get back any errors or content
                        string content = response.Content.ReadAsStringAsync().Result;
                        // show error if service failed
                        if (response.IsSuccessStatusCode == false)
                        {
                            throw new Exception(content);
                        }
                        // try to convert the object back from the service call
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<TEntity>(content);
                    }
                }
            }
        }
    }
