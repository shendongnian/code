     class Program
    {
        static void Main(string[] args)
        {
            try
            {
                String firstLine;
                var fileStream = new FileStream(@"C:\Users\user\Desktop\AssetsImportCompleteSample.csv", FileMode.Open,
                    FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    firstLine = streamReader.ReadLine();
                }
                if (firstLine != null)
                {
                    var values = firstLine.Split(',');
                    Console.WriteLine(firstLine);
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = values[i].Trim();
                        Console.WriteLine(values[i]);
                    }
                    if (values.Length == 4)
                    {
                        if (values[0] == "SRM_SaaS_ES" && values[1] == "MXASSETInterface" && values[2] == "AddChange" &&
                            values[3] == "EN")
                        {
                            Console.WriteLine("head is correct");
                        }
                        else
                        {
                            Console.WriteLine("head is incorrect");
                        }
                    }
                    else
                    {
                        Console.WriteLine("header is Invalid");
                    }
                }
                else
                {
                    Console.WriteLine("header is Invalid");
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Please check if file is available or path is correct", e.Message);
            }
            Console.ReadLine();
        }
    }
