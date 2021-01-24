    public class MySingleton {
       private bool initialized=false;
       private SemaphoreSlim mutex = new SemaphoreSlim(1, 1);
       public async Task DoStuff() {
           if (!initialized) {
               await mutex.WaitAsync();
               try {
                   if (!initialized) {
                       await InitAsync();
                       initialized = true;
                   }
               } finally {
                   mutex.Release();
               }
           }
           DoTheRealStuff();
       }
       private async Task InitAsync() {
           await Stuff();
       }
    }
