     class InputNode
        {
            public DateTime dateTime;
            public string dollarAmount;
        }
        class Program
        {
            public static void ReadFile(string filename)
            {
                InputNode inputNode = new InputNode();
                if (System.IO.File.Exists(filename))
                {
                    var reader = new StreamReader(File.OpenRead(filename));
                    
                    while (!reader.EndOfStream)
                    {
                        var input = reader.ReadLine();
                        var values = input.Split(',');
                        inputNode.dateTime = Convert.ToDateTime(values[0]);
                        inputNode.dollarAmount = values[1];
    
                    }
                }
            }
