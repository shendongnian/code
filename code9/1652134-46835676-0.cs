    public class JsonReaderThatReturnsNull : JsonReader
    {
        public override bool Read()
        {
            return true;
        }
        public override object Value => null;
    }
