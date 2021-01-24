    List<RootObject> results;
    using (var stream = HWR_Response.GetResonseStream())
    {
        results = JsonExtensions.DeserializeObjects<RootObject>(stream).ToList();
    }
