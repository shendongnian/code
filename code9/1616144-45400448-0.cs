    static void Read()
    {
        string[] myFile = File.ReadAllLines(@"C:\1.txt");
        for(int index = 0; index < myFile.Length; index++)
        {
            if(myFile[index].Contains("[PRG]"))
            {
                
                Console.WriteLine(myFile[index + 1].Replace("name", "").Trim());
            }
        }
    }
    static void Main(string[] args)
    {
        Read();
    }
