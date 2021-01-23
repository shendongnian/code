    public class ResponseVM
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Message { get; set; }
        public string Image { get; set; }
        [DisplayFormat(DataFormatString = "{0:...}")] // your format
        public DateTime Time { get; set; }
    }
