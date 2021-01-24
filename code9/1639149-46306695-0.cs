    [DataContract]
    public class newses
    {
        [DataMember(Name = "id")] //This is what you need to add
        public int id;
        
        //Do the same for all other fields        
    }
