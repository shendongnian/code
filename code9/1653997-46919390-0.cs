    [Serializable]
    public class MyClass 
    {
        public SubClass Child {get; set;}
	
		//[Serializable] //-- not serializable
        public class SubClass 
        {
            public int Id {get; set;}
	        public string Name {get;set;}
        }
    }
