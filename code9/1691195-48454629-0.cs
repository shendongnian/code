            string input = "FP10.01";
            string[] _input = input.Split('.');
            string num = find(_input[0]);
            public string find(string input)
            {
                char[] _input = input.ToArray();
                int number;
                string result = null;
                foreach (var item in _input)
                {                
                    if (int.TryParse(item.ToString(), out number) == true)
                    {
                        result = result + number;
                    }
                }
    
                return result;
            }
