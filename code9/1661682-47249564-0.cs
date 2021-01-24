    class Program
    {
        static void Main(string[] args)
        {
            var basePath = @"C:\Users\Angelo\Desktop\ExerciseTest";
    
            DirectoryInfo startDirectory = new DirectoryInfo(basePath);
            IterateDirectory(startDirectory, 0);
    
            Console.ReadLine();
        }
    
        private static void IterateDirectory(DirectoryInfo info, int level)
        {
             var indent = new string('\t', level);
             Console.WriteLine(indent + info.Name);
             var subDirectories = info.GetDirectories();
    
             foreach(var subDir in subDirectories)
             {
                 IterateDirectory(subDir, level + 1);
             }
         }
     }
