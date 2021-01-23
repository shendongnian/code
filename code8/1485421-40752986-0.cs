    class Program {
      static void Main(string[] args) {
         var list = new List<string> { "1", "2" };
         Task[] myTasks = new Task[ list.Count ];
         int i = 0;
         foreach( string item in list ) {
            // Spin off a background task to process the file we just downloaded
            myTasks[ i++ ] = Task.Factory.StartNew( () =>
            {
               //Extract the zip file referred to by  download_location_hw
               // Process the extracted zip file
               ProcessFile();
               } );
         }
      
      Task.WaitAll( myTasks );
         Console.WriteLine( "in main after processing..." );
         Console.Read();
      }
      private static void ProcessFile() {
         Console.Write( "Processed..." );
      }
    }
