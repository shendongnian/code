    List<string> datas = new List<string>
            {
                "\nP","r","o" //All data here
            };
            foreach (var data in datas)
            {
                PrintData(data);
            }
    private static void PrintData(string data)
        {
            Console.Write(data);
            Thread.Sleep(60);
        }
