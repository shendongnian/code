    public class Rootobject
    {
        public Result result { get; set; }
    }
    public class Result
    {
        public int appid { get; set; }
        public int contextid { get; set; }
        public Items items { get; set; }
    }
    public class Items
    {
        [JsonProperty(PropertyName = "Skin: Graffiti Hunting Rifle")]
        public int SkinGraffitiHuntingRifle { get; set; }
    }
