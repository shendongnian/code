     public class MemoryPostedFile : HttpPostedFileBase
    {
        private readonly byte[] fileBytes;
        public MemoryPostedFile(byte[] fileBytes, string fileName = null)
        {
            this.fileBytes = fileBytes;
            this.FileName = fileName;
            this.InputStream = new MemoryStream(fileBytes);
        }
        public override void SaveAs(string filename)
        {
            File.WriteAllBytes(filename, fileBytes);
        }
        public override string ContentType => base.ContentType;
        public override int ContentLength => fileBytes.Length;
        public override string FileName { get; }
        public override Stream InputStream { get; }
    }
