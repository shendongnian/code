                string[] inputs = {
                    "The controller for path '/MyApplication/Scripts/jquery-1.10.2.min.js' was not found or does not implement IController.",
                    "The controller for path '/MyApplication/Content/bootstrap.min.css' was not found or does not implement IController."
                };
                string pattern = @"The controller for path '(?'path'.+)\.(?'ext'.+)'";
                foreach (string input in inputs)
                {
                    
                    Match match = Regex.Match(input, pattern);
                    string ext = match.Groups["ext"].Value;
                    if (match.Success && match.Groups["ext"].Value != "cs")
                    {
                        Console.WriteLine(match.Groups["path"].Value + "." + match.Groups["ext"].Value);
                    }
                }
                Console.ReadLine();
