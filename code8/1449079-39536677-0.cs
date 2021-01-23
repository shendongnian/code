    public class MyToggableConsole
    {
        public bool On { get; }
        public void WriteLine(string message)
        {
            if (!On)
               return;
            Console.WriteLine(msg);
        }
        //Do same for all other `WriteLine` and `Write` overloads you need.
    }
