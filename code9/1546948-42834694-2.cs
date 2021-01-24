    public interface IReadWriter
    {
        void Read(Test test, string filenName);
        void Write(Test test, string filenName);
    }
    public class Test
    {
        public string Type;
        public Dictionary<string, string> Dic1;
        public Dictionary<string, int> Dic2;
        public IReadWriter readWriter;
        public Test(IReadWriter readWriter)
        {
            this.readWriter = readWriter;
        }
        public void Read(string fileName)
        {
            readWriter.Read(this, fileName);
        }
        public void Write(string fileName)
        {
            readWriter.Write(this, fileName);
        }
        public Test WithReadWriter(IReadWriter other)
        {
            Test x = new Test(other);
            //if (x.Type.Equals(this.Type)) { return this; }
            x.Dic1 = this.Dic1;
            x.Dic2 = this.Dic2;
            return x;
        }
    }
