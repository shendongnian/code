    class Program
    {
        static void Main(string[] args)
        {
            foreach ( var f in CompareFiles(@"x:\tmp\dir_1", @"x:\tmp\dir_2") )
            {
                Console.WriteLine(f);
            }
            Console.ReadKey();
        }
        public static List<string> CompareFiles(string comparePath1, string comparePath2)
        {
            //Queries the given directory for filenames
            var fileList1 = (from file in new DirectoryInfo(comparePath1).GetFiles("*.*", SearchOption.TopDirectoryOnly)
                             where !file.Attributes.HasFlag(FileAttributes.Hidden)
                             select file.Name).ToList();
            
            var fileList2 = (from file in new DirectoryInfo(comparePath2).GetFiles("*.*", SearchOption.TopDirectoryOnly)
                             where !file.Attributes.HasFlag(FileAttributes.Hidden)
                             select file.Name).ToList();
            return fileList1.Except(fileList2)
                            .Select(file => Path.Combine(comparePath1, file))
                            .ToList();
        }
    }
