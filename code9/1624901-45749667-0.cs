    static string content;
        static string outputFile = @"C:\Users\Desktop\ShoeRack.txt";
        public static void sorting()
        {
            try
            {
                string[] scores = System.IO.File.ReadAllLines(@"C:\Users\Desktop\ShoeRack.txt");
                //Split into two lists:  one that is Puma, one that is the others
                List<string> pumaEntries = new List<string>();
                List<string> otherEntries = new List<string>();
                foreach (string item in scores)
                {
                    if (item.Split(',')[0].ToUpper() == "PUMA")
                    {
                        pumaEntries.Add(item);
                    }
                    else
                    {
                        otherEntries.Add(item);
                    }
                }
                //Now sort the puma entries
                var sorted = pumaEntries.OrderBy(x => x.Split(',')[2]);
                //Now output the "Other" entries, then the Puma ones
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@outputFile))
                {
                    foreach (string dat in otherEntries)
                    {
                        file.WriteLine(dat);
                    }
                    foreach (string dat in sorted)
                    {
                        file.WriteLine(dat);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }
