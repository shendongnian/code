     public static void Main(string[] args)
     {
         var t1 = Task.Factory.StartNew(MethodA);           
         var t2 = Task.Factory.StartNew(MethodB1).ContinueWith(task => MethodB2());                                              
     }
