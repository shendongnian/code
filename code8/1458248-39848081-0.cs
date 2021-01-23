    public class GuvenlikNoktası
    {
        public int Id { get; set; }
        public string GuvenlikNoktası1 { get; set; }
        public string KartNo { get; set; }
        public int Sira { get; set; }
    }
    public class GuvenlikNoktaArray
    {
        public IList<GuvenlikNoktası> GuvenlikNoktası { get; set; }
    }
    public class Example
    {
        public GuvenlikNoktaArray GuvenlikNoktaArray { get; set; }
    }
