    public static async Task<TBody> ReadFromJsonAsync<TBody>(this HttpResponseMessage response)
    {
        if (response.Content == null) return default(TBody);
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TBody>(content);
    }
