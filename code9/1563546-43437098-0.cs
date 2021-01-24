    var lines = File.ReadAllText("C:\\My File2.txt");
            var seperatedStrings = lines.Split('!');
            foreach (var oneString in seperatedStrings)
            {
                if (oneString.Contains("access-list"))
                {
                    Console.WriteLine("Access-List: " + oneString);
                }else if (oneString.Contains("nat"))
                {
                    Console.WriteLine("Nat: " + oneString);
                }else  if (oneString.Contains("interface"))
                {
                    Console.WriteLine("Interface: " + oneString);
                }
            }
