    public enum DisplaySettingType
    {
        Manual, Auto, None
    }
    public class DisplaySetting
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public DisplaySettingType Type { get; set; }
    }
