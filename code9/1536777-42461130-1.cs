    class Animal{  // this is said to be a good practise
      private string name = "Cat";
      public string Name{
        get{return this.name;}
        set{this.name = value;}
      }
    }
    
    class Animal{  // this is said to be bad practise
       public name = "Cat";
    }
