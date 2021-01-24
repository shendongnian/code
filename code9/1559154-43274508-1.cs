    public class MeFileWatcher
        : FileWatcher
    {
        protected override void ProcessLine(string line)
        {
            Console.WriteLine ("NEW LINE ADDED -> {0}", line);
        }
    }
    MeFileWatcher meFileWatcher = new MeFileWatcher("D:\\testData\\meFile.txt");
