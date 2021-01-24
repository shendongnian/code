    class C : A, B
    {
        [JsonProperty]
        string A.Name { get; set; }
        [JsonProperty]
        string B.Name { get; set; }
    }
