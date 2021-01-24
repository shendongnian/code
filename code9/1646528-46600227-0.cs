     string input = "SASASA EXCEPT ASASA UNION"; // test input here is your input string which is a sql query
    
    
                int UnionIndex = input.IndexOf("UNION");
    
                int ExceptIndex = input.IndexOf("EXCEPT");
    
    
                List<string> SplitArray = new List<string>();  // here is the list with the sub strings
    
                if (UnionIndex < ExceptIndex)
                {
                    SplitArray = input.Split(new[] { "UNION" },
                                StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                else if (ExceptIndex < UnionIndex)
                {
                    SplitArray= input.Split(new[] { "EXCEPT" },
                                StringSplitOptions.RemoveEmptyEntries).ToList();
                }
