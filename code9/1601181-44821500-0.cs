            var recordsToSaveInPassFile = new List<Class>();
            var recordsToSaveInGeneralFile = new List<Class>();
            var lines = File.ReadAllLines(@"C:\temp\data.csv", Encoding.GetEncoding(1252));
            
            foreach (var line in lines)
            {
                var items = line.Split(';');
                int parsedAge;
                if (int.TryParse(items[0], out parsedAge))
                {
                    if(parsedAge > 24)
                    {
                       var recordToPass = new Class
                       {
                        Age = items[0],
                        item2 = items[1]
                       };
                       
                       recordsToSaveInPassFile.Add(recordToPass);
                    }
                    else if(parsedAge > 19)
                    {
                       var recordToGeneral = new Class
                       {
                        Age = items[0],
                        item2 = items[1]
                        };
                       recordsToSaveInGeneralFile.Add(recordToGeneral);
                    }
                    continue;
                }
                Console.WriteLine($@"'{line}': could not be parsed");
            }
