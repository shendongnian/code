                string input =	File.ReadAllText(your_file_path);
    			string output = string.Empty;
    			input.Split(new[] { Environment.NewLine } , StringSplitOptions.RemoveEmptyEntries).
    				Skip(1).ToList().
    				ForEach(x =>
    				{
    					output += x.EndsWith("\\r\\n") ? x + Environment.NewLine 
                                                       : x.Replace("\\n"," ");
    				});
