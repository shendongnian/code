    public class Program
    {
        volatile static int fileNameCounter = 1;
        static void Main(string[] args)
        {
            var listOfTasks = new List<Task>()
            {
                new Task(() => ReadWriteWeb("http://www.hawaii.edu")),
                new Task(() => ReadWriteWeb("http://www.hawaii.edu")),
                new Task(() => ReadWriteWeb("http://www.hawaii.edu")),
                new Task(() => ReadWriteWeb("http://www.hawaii.edu"))
            };
            listOfTasks.AsParallel().ForAll(task => task.Start());
            Console.ReadLine();
        }
        static async void ReadWriteWeb(string Url)
        {
            Console.WriteLine($"File {fileNameCounter} complete");
            try
            {
                using (WebClient WebC = new WebClient())
                {
                    string WebContents = await WebC.DownloadStringTaskAsync(Url);
                    Console.WriteLine(WebContents);
                    using (StreamWriter SW = new StreamWriter($"myFile{fileNameCounter++}"))
                        SW.WriteLine(WebContents + ".  " + "The lenght of file  is {0}", WebContents.Length);
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The web content cannot be reached");
                Console.WriteLine(e.Message);
            }
        }
    }
