    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string space = " ";
            string filePath1 = @"D:\mysong1.mp3";
            string filePath2 = @"D:\mysong2.mp3";            
            List<string> songFiles = new List<string>();
            songFiles.Add(filePath1);
            songFiles.Add(filePath2);            
            var playList = songFiles.Aggregate((a, b) => a + space + b);
            
            Process.Start("wmplayer.exe", playList);            
        }
    }
