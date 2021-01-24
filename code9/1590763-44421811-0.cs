     public static class FirstClass{
    
        public static async System.Threading.Tasks.Task FirstClassMethod() 
            {
                return await Task.WhenAll(
                    SecondClass.SecondClassMethod(),
                    ThirdClass.ThirdClassMethod()
                );
            }
     }
    
     public static class SecondClass{
    
        public static async System.Threading.Tasks.Task SecondClassMethod() 
            {
    
            }
     }
    
     public static class ThirdClass{
    
        public static async System.Threading.Tasks.Task ThirdClassMethod() 
            {
    
            }
     }
