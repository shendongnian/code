    using Newtonsoft.Json;
    public virtual async Task<JObject> RequestCRM(HttpMethod method, string query, string pag, bool annotations)
    {
        JObject responseObject = new JObject();
        HttpResponseMessage response = await RequestCRMAsync(method, query, pag, annotations);
        if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent)
        {
            responseObject = JsonConvert.DeserializeObject<JObject>(response.Content.ReadAsStringAsync().Result);
        }
        else
        {
            throw new CrmHttpResponseException(response.Content);
        }
        return responseObject;
    }
