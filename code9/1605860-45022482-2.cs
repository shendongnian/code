    class ConsoleReader {
      private readonly BlockingCollection<int> buffer = new BlockingCollection<int>(1);
      private readonly Thread readThread;
      public ConsoleReader() {
        readThread = new Thread(() => {
          if (Console.IsInputRedirected) {
            int i;
            do {
              i = Console.Read();
              buffer.Add(i);
            } while (i != -1);
          } else {
            while (true) { 
              var consoleKeyInfo = Console.ReadKey(true);
              if (consoleKeyInfo.KeyChar == 0) continue;  // ignore dead keys
              buffer.Add(consoleKeyInfo.KeyChar);
            }
          }
        });
      }
    
      public void Start() {
        readThread.Start();
      }
    
      public int? Next {
        get {
          int result;
          return buffer.TryTake(out result, 0) ? result : default(int?);
        }
      }
    }
