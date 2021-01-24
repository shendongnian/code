    public async Task<string> insert(string x, string y, string z) {
        using (var client = new HttpClient()) {
            client.BaseAddress = new Uri("http://localhost:20968/Service1.svc/");
            //UriTemplate = "insert/{username}/{userpassword}/{usermobile}"
            var url = string.Format("insert/{0}/{1}/{2}", x, y, z);
            System.Diagnostics.Debug.WriteLine(url);
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            System.Diagnostics.Debug.WriteLine(request);
            var result = await client.SendAsync(request);
            return await result.Content.ReadAsStringAsync();
        }
    }
