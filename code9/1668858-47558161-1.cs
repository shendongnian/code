    [JsonConverter(typeof(ArrayToObjectConverter<ChildModel>))]
    class ChildModel
    {
        [JsonArrayIndex(0)]
        public int ID { get; set; }
        [JsonArrayIndex(1)]
        public string StatusId { get; set; }
        [JsonArrayIndex(2)]
        public DateTime ContactDate { get; set; }
        [JsonArrayIndex(3)]
        public string State { get; set; }
        [JsonArrayIndex(4)]
        public string Status { get; set; }
        [JsonArrayIndex(5)]
        public string CustomerName { get; set; }
        [JsonArrayIndex(6)]
        public DateTime WorkStartDate { get; set; }
        [JsonArrayIndex(7)]
        public DateTime WorkEndDate { get; set; }
        [JsonArrayIndex(8)]
        public string Territory { get; set; }
        [JsonArrayIndex(9)]
        public string CustType { get; set; }
        [JsonArrayIndex(10)]
        public int JobOrder { get; set; }
        [JsonArrayIndex(12)]
        public string Link { get; set; }
    }
