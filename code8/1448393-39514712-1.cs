    if (!result.IsSuccessStatusCode)
    {
        string msg = result.Content.ReadAsStringAsync().Result;
        throw new Exception(msg);
    }
    result.EnsureSuccessStatusCode();
