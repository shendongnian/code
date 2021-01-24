    public class MyController
    {
       private IStoreInts storage;    
       public MyController(IStoreInts storage){this.storage = storage;}
        
        [HttpPost]
        public void Index(int value){
          storage.Add(value);
         }
    }
