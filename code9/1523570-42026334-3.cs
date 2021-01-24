    List<JObject> objs;
    using (var stream = HWR_Response.GetResonseStream())
    {
        objs = JsonExtensions.DeserializeObjects<JObject>(stream).ToList();
    }
			
