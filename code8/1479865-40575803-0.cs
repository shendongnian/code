    public static A FromJson(string input) 
    {
        var json = JToken.Parse(input);
        json["OrganizationAttribute"].Remove();
        return JsonConvert.DeserializeObject<A>(json.ToString());
    }
