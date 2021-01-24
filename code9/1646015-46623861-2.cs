     public static void Main(string[] args)
     {
         var t1 = Task.Factory.StartNew(MethodA);           
         var t2 = Task.Factory.StartNew(MethodB1).ContinueWith(task => MethodB2());   
         Task.WaitAll(t1, t2); // If you want to wait here for finishing the above tasks                                           
     }
