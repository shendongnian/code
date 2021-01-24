      public class Test:TestBase {
  
        public Test(): base() { 
         
        }
        
        public string GetExample() { 
         return example;
        }
   
    }
    
        public class TestBase {
        protected readonly string example = "";
       
         public TestBase() { 
          example ="hi";
        }
   
    }
