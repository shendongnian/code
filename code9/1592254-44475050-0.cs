     public static class ClientConfig{
        
        public static string Name{get;set;}
        public static bool IsAdult{get;set;}
        public static int Age{get;set;}
           
         public static void Load(){
         // load your values 
        // ClientConfig.Name = name from file etc.
        }
        
        
        public static void Save(string newName, int age, bool value){
         // save your values to the config file
        }
        }
