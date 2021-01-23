    public class PostedFile {
        public int ContentLength { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
    public class WebApiModel {
        public DateTime SubmittedDate { get; set; }
        public string Comments { get; set; }
        public List<PostedFile> Files { get; set; }
    }
