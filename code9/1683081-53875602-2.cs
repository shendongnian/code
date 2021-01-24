    using System;
    using System.Threading.Tasks;
    
    namespace so {
        sealed class Garbage : IDisposable {
            public void Dispose() {
                Console.WriteLine("Disposing Garbage");
            }
        }
    
        // Garbage is safely Disposed() only after delay is done
        class Program {
            public static async Task Main() {
                using (Garbage g = new Garbage()) {
                    Console.WriteLine("Delay Starting");
                    await Task.Delay(1000);
                    Console.WriteLine("Delay Finished");
                }
            }
        }
    }
