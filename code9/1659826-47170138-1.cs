    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "aeevts.dll";
            string path = Environment.ExpandEnvironmentVariables(@"%windir%\Sysnative\" + fileName);
            //path should be 'C:\Windows\System32\'+fileName;
            Console.WriteLine(path);
            bool fileExists = File.Exists(path); //Always returns false
            Console.WriteLine(fileExists);
            Console.Read();
        }
    }
