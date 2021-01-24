      public static void Main(string[] args)
            {
                //Your code goes here
                List<DateTime> dtList = new List<DateTime>(){
                    DateTime.Now
                };
                
                Console.WriteLine("Before count " + dtList.Count());
                
                dtList.Clear();
                
                Console.WriteLine("After count " + dtList.Count());
            }
