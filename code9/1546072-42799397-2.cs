     //This is getting and setting automatically, which is why they are called Auto-Implemented Properties
             
     public string Name {get; set;}
    
     public string Name
    {
    get { return _name; }
    set { _name = value; }
    }
    //You can also use access modifiers private, public, protected within them to determine if once you instantiate an object can you get & set information.
     
     public string Topic {get; private set; }
    
    //An example of how you can instantiate would be.
     var constituent = new constituent();
     constituent.Id = "1"; //Setting the value of ID
     var constId = constituent.Id; //store a value in a variable
