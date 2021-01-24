    internal class TestClassBuilder<T> : where T : TestClass
    {
       int Id {get; set;}
    
       public T WithId(int id)
       {
         this.Id = id;
         return this;
       }
       
       public virtual T Build()
       {      
            return new T()
             {
               if(this.Id)
                   Id = this.Id; // if you chose to set it, then assign it
               else
                Id = GetRandomId() // you can figure a solution here
             }
        }  
    }
