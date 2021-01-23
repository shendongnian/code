        public async static Task<IEnumerable<RootObjectUtrechtCity>> GetUtrechtCity()
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://stallingsnet.nl/api/1/parkingcount/utrecht");
            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<RootObjectUtrechtCity>>(result);
            return data;
        }
