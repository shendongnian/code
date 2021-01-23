    public class Program
        {
            public static void Main(string[] args)
            {
                var list = new List<Dictionary<string, string>>();
                Console.WriteLine("Put in the path to your .csv file");
                var response1 = Console.ReadLine();
    
                Console.WriteLine("Initializing...");
                // Read All of the lines in the .csv file
                var csvFile = File.ReadAllLines(response1);
    
    
                // Get The First Row and Make Those You Field Names
                var fieldNamesArray = csvFile.First().Split(',');
                // Get The Amount Of Columns In The .csv
                // Do the -1 so you can use it for the indexer below
                var fieldNamesIndex = fieldNamesArray.Count() - 1;
                // Skip The First Row And Create An IEnumerable Without The Field Names
                var csvValues = csvFile.Skip(1);
                // Iterate Through All Of The Records
                foreach (var item in csvValues)
                {
                    
                    var newDiction = new Dictionary<string, string>();
                    for (int i = 0; i < fieldNamesIndex;)
                    {
                        
                        foreach (var field in item.Split(','))
                        {
                            
                            // Think Of It Like This
                            // Each Record Is Technically A List Of Dictionary<string, string>
                            // Because When You Split(',') you have a string[]
                            // Then you iterate through that string[]
                            // So there is your value but now you need the field name to show up
                            // That is where the Index will come into play demonstrated below
                            // The Index starting at 0 is why I did the -1 on the fieldNamesIndex variable above
                            // Because technically if you count the fields below its actually 6 elements
                            //
                            // 0,1,2,3,4,5 These Are The Field Names
                            // 0,1,2,3,4,5 These Are The Values
                            // 0,1,2,3,4,5
                            //
                            // So what this is doing is int i is starting at 0 for each record
                            // As long as i is less than fieldNamesIndex
                            // Then split the record so you have all of the values
                            // i is used to find the fieldName in the fieldNamesArray
                            // Add that to the Dictionary
                            // Then i is incremented by 1
                            // Add that Dictionary to the list once all of the values have been added to the dictionary
                            //
    
                            
                            // Add the field name at the specified index and the field value
                            newDiction.Add(fieldNamesArray.ElementAt(i++), field);
                            
                        }
                        list.Add(newDiction);
    
                    }
                }
    
    
                Console.WriteLine("Would You Like To Convert To Json Now?");
                Console.WriteLine("[y] or [n]");
    
                var response = Console.ReadLine();
    
                if (response == "y")
                {
                    Console.WriteLine("Where Do You Want The New File?");
                    var response2 = Console.ReadLine();
                    // Serialize the list into your Json
                    var json = JsonConvert.SerializeObject(list);
    
                    File.Create(response2).Dispose();
                    File.AppendAllText(response2, json);
    
                    Console.WriteLine(json);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Ok See You Later");
                    Console.ReadLine();
                }
    
            }
    
        }
