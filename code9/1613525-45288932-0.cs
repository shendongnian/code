    public async Task<HttpResponseMessage> SubmitInspection(List<object> newitems, List<object> childs)
        {
            //how do i add the above lists to one item to pass to the http body
            //stuck here = newitems and childs lists
            var myContent = Newtonsoft.Json.JsonConvert.SerializeObject(new { newitems, childs });
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await new HttpClient().PostAsync("", byteContent);
            return response;
        }
