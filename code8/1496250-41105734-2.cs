    static void Main(string[] args) {
         // This is a terrible thing to do but it's for illustration purposes
         Task task = Method1();
         task.Wait();
         // Some other work
     }
     private static async Task Method1() {
         await Method2();
         // Some other work
     }
     private static async Task Method2() {
         await Method3();
         // Some other work
     }
     private static async Task Method3() {
        await Task.Delay(1000);
     }
