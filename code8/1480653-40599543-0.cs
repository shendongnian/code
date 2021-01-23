     public static void Main(string[] args)
     {
         Demo demo = new Demo();
         string target;
         demo.Something = (a, b) =>
         {
             target = a;
             return true;
         };
         //Call something with params
         demo.Something("foo", 1);
     }
