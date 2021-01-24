    [DataContract]  
    class Food
    {  
        [DataMember]  
        public ArrayList<Fruit> Fruit { get; set; }  
    }
    
    [DataContract]
    class Fruit
    {  
        [DataMember]  
        public string Name { get; set; }  
      
        [DataMember]  
        public string Colour { get; set; }  
    
        [DataMember]  
        public string Size{ get; set; }  
    }
