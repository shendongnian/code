    [DataContract]
    public class ItemSend
    {
        private int _id;
        private int _part;
       
        [DataMember]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    
        [DataMember]
        public int Part
        {
            get { return _part; }
            set { _part = value; }
        }
    }
