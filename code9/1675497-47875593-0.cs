    public class UnseekableStream : MemoryStream {
        public override bool CanSeek => false;
    }
    using (var memStream = new UnseekableStream()) {
        using (var archive = new ZipArchive(memStream, ZipArchiveMode.Create, true)) { 
       }
     }
