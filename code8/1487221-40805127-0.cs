    class MyRequest{
        public string UserName {get; set;}
        public string Type {get; set;}
        pulic CustomEnum? TypeAsEnum 
        { 
            get{
                CustomEnum value;
                return Enum.TryParse(typeof(CustomEnum), out value) ? value : (CustomEnum?)null; 
            }
        }
    }
