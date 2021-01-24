     using (StreamReader reader = OpenText("test1.txt"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var matches = Regex.Matches(line, "[0-9]+");
                            foreach (var match in matches)
                            {
                                //do something...
                                Debug.WriteLine("point " + match);
    
                            }
                        }
                    }
