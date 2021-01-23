            public void Main(string[] args)
            {
                var fileStream = new FileStream(@"D:\Practise\test.txt", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] data = line.Split(new char[] { '(' },StringSplitOptions.RemoveEmptyEntries);
                        string bikeName = data[0].Trim().Split(' ').Last();
                        bikeName = bikeName.Remove(bikeName.Length - 1);
                        string[] usageData = data[1].Split(new char[] { ';' },StringSplitOptions.RemoveEmptyEntries);
                        string issuedBike= usageData[0].Trim().Split(' ')[2];
                        string inUseBike = usageData[1].Trim().Split(' ')[2];
    
                        Console.WriteLine("Name:" + bikeName);
                        Console.WriteLine("Total:" + issuedBike);
                        Console.WriteLine("InUse:" + inUseBike);
                        Console.WriteLine();
                    }
                }
                Console.ReadLine();
            }
