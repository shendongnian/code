    static void JsonConvert()
    {
        string sJSON = @"[{""dateNumeric"":1216000000,""hourOfDay"":0,""customerNumber"":12,""storedepartment"":[{""department"":333,""descriptionOfDepartment"":""Department A""},{""department"":111,""descriptionOfDepartment"":""Department B""}]},{""dateNumeric"":1216000000,""hourOfDay"":3,""customerNumber"":3,""storedepartment"":[{""department"":999,""descriptionOfDepartment"":""Department X""},{""department"":888,""descriptionOfDepartment"":""Department Y""}]}]";
        var storeDetail = Newtonsoft.Json.JsonConvert.DeserializeObject<List<StoreDetail>>(sJSON);
        //iterate your list here
    }
    public class StoreDetail
    {
        [JsonProperty("dateNumeric")]
        public string DateNumeric { get; set; }
        [JsonProperty("hourOfDay")]
        public int HourOfDay { get; set; }
        [JsonProperty("customerNumber")]
        public int CustomerNumber { get; set; }
        [JsonProperty("storedepartment")]
        public List<StoreDepartment> StoreDepartment { get; set; }
    }
    public class StoreDepartment
    {
        [JsonProperty("department")]
        public int Department { get; set; }
        [JsonProperty("descriptionOfDepartment")]
        public string DescriptionOfDepartment { get; set; }
    }
