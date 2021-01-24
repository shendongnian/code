        public string Name { get; set;} 
        public int FooID {get; set;}
        public override int GetHashCode()             
        {  
               return FooID; 
        }
         public override bool Equals(object obj) 
        { 
                 return Equals(obj as Foo); 
        }
        
        public bool Equals(Foo obj)
         { 
              return obj != null && obj.FooID == this.FooID; 
         }
    }
