    [DataContract]
    public class Sample
    {
        public object[] Values { get; set; }
    
        [DataMember]
        public byte[] SerializableValues
        {
            get
            {
                try
                {
                    return ToBytes( Values );
                }
                catch ( Exception e )
                {
                    return null;
                }
            }
    
            set
            { 
                try
                {
                    Values = FromBytes( value );
                }
                catch ( Exception e )
                {
                    Values = null;
                }
            }
        }
    }
