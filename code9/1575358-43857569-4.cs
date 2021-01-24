    public class Program
    {
        public static void Main(string[] args)
        {
            foreach (string item in GetWords(@"C:\Temp\file.txt"))
            {
                Console.WriteLine("{0} ", item);
            }
        }
        
        public static IEnumerable<String> GetWords(string path) 
        {
            if (File.Exists(path))
            {
                foreach (var line in File.ReadAllLines(path))
                {
                    yield return line;
                }
            }
            else
            {
                Console.WriteLine("Directory not correct");
                yield return null;
            }
        }
    }
