    class ViewModel
    {
        public ViewModel()
        {
            using (var sr = new StreamReader(StreamObject.text, Encoding.UTF8, true))
                Text = sr.ReadToEnd();
        }
        //this method is called when your "Save" button or similar is clicked
        public void SaveToDb()
        {
            lock (_lockObject)
            {
                var str = value;
                using (textStream = new MemoryStream())
                {
                    using (var writer = new BinaryWriter(textStream, Encoding.UTF8, true))
                    {
                        writer.Write(Encoding.UTF8.GetBytes(str));
                    }
                    textStream.Position = 0;
                    StreamObject.text = null;
                    StreamObject.text = textStream;
                }
            }
        }
        public String Text
        {
            get;set;
        }
    }
