    public class MyXmlReader : XmlTextReader
    {
        public MyXmlReader(string filePath) : base(filePath)
        {
        }
        
        public override bool Read()
        {
            if (base.Read())
            {
                if (Name == "FullName")
                    return base.Read();
    
                return true;
            }
    
            return false;
        }
    }
