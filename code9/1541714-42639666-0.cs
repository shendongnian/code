     static void Main(string[] args)
        {
            //Sample data declaration
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            data.Add("Hello", new List<string>{"1", "2", "4"});
            data.Add("Foo", new List<string> { "3", "4", "7" });
            data.Add("World", new List<string> { "3", "4", "7" });
          
            DicToExcel(data, @"D:\my.csv");
        }
