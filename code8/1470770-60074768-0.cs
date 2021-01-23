    using (HttpClient http = new HttpClient { BaseAddress = new Uri(url) }) {
        http.DefaultRequestHeaders.Accept.Clear();
        http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/image"));
        HttpResponseMessage result = http.GetAsync(url).Result;
        if (result.IsSuccessStatusCode) {
            Stream stream = result.Content.ReadAsStreamAsync().Result;
            return Image.FromStream(stream);
        }
    }
