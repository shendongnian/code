    [Serializable]
    public class Human
    {
        public string[] Address; 
        private string _name;
        
        public int Weight {get; set;} // switched
        public int Age {get;set;}
        
        public string Name {get{return _name;} set{_name=value;}}
    }
