    public class MySingleton {
       private bool initialized=false;
       private object sync = new object();
       public async Task DoStuff() {
           if (!initialized) {
               lock (sync) {
                   if (!initialized) {
                       await InitAsync();
                       initialized = true;
                   }
               }
           }
           DoTheRealStuff();
       }
       private async Task InitAsync() {
           await Stuff();
       }
    }
