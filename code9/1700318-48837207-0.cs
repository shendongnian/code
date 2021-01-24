    class FileWrapper
    {
        public string File { get; set; }
        public static void WriteByteArray(string file, long offset, byte[] buffer)
        {
            // The real work goes here
        }
        public void WriteByteArray(long offset, byte[] buffer)
        {
            // Just call the static method and pass the instance property for the file path
            WriteByteArray(this.File, offset, buffer);
        }
    }
