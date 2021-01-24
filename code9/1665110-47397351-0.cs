    class Program
    {
       static void Main(string[] args)
       {
          ReaderDemo rd = new ReaderDemo();
          GenPrimes(rd).ContinueWith((t) => {
             if (t.IsFaulted)
                Console.WriteLine(t.Exception.ToString());
             else
                Console.WriteLine(rd.value);
          }).Wait();
       }
    
       static async Task GenPrimes(ReaderDemo rd)
       {
          using (var pout = new System.IO.Pipes.AnonymousPipeServerStream(System.IO.Pipes.PipeDirection.Out))
          using (var pin = new System.IO.Pipes.AnonymousPipeClientStream(System.IO.Pipes.PipeDirection.In, pout.ClientSafePipeHandle))
          {
             var writeTask = WriterDemo.WriteTo(pout);
             await rd.LoadFrom(pin);
             await writeTask;
          }
       }
    }
    
    class ReaderDemo
    {
       public string value;
    
       public Task LoadFrom(System.IO.Stream input)
       {
          return Task.Run(() =>
          {
             using (var r = new System.IO.StreamReader(input))
             {
                value = r.ReadToEnd();
             }
          });
       }
    }
    
    class WriterDemo
    {
       public static Task WriteTo(System.IO.Stream output)
       {
          return Task.Run(() => {
             using (var writer = new System.IO.StreamWriter(output))
             {
                writer.WriteLine("2");
                for (int i = 3; i < 10000; i+=2)
                {
                   int sqrt = ((int)Math.Sqrt(i)) + 1;
                   int factor;
                   for (factor = 3; factor <= sqrt; factor++)
                   {
                      if (i % factor == 0)
                         break;
                   }
                   if (factor > sqrt)
                   {
                      writer.WriteLine("{0}", i);
                   }
                }
             }
          });
       }
    }
