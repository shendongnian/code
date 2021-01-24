        HttpResponseMessage rspn = await _HttpClient.GetAsync(geturi);
        string response = await rspn.Content.ReadAsStringAsync();
        response = response.Replace(Environment.NewLine, string.Empty);
        response = response.Replace(@"\", string.Empty);
        response = response.Substring(1, response.Length - 2);
        JsonArray root = JsonValue.Parse(response).GetArray();
