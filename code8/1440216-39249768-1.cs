    public class RootObject
    {
        public string description { get; set; }
        public int value { get; set; }
    }
    var s = JsonConvert.SerializeObject(new List<RootObject> {
                new RootObject
                {
                    description = "upper-left",
                    value = 23
                },
                new RootObject
                {
                    description = "upper-right",
                    value = 24
                }
            }, jss);
