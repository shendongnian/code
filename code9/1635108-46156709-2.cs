    String firstLine;
    var fileStream = new FileStream( @ "C:\Users\user\Desktop\AssetsImportCompleteSample.csv", FileMode.Open,
		FileAccess.Read);
     using(var streamReader = new StreamReader(fileStream, Encoding.UTF8)) {
    firstLine = streamReader.ReadLine();
    }
    var values = firstLine.Split(',');
    for (int i = 0; i < values.Length; i++) {
	values[i] = values[i].Trim();
    }
    if (values.Length == 4)
                    {
                        int count=0;
                        IList<string> newList = new List<string> { "MXASSETInterface", "SRM_SaaS_ES", "EN", "AddChange" };
                        for (int i = 0; i < values.Length; i++)
                        {
                            if (newList.Contains(values[i]))
                            {
                                count++;
                                newList.Remove(values[i]);
                            }
                        }
                        if (count == 4)
                        {
                            Console.WriteLine("head is correct");
                        }
                        else
                        {
                            Console.WriteLine("head is incorrect");
                        }
                        
                    }
