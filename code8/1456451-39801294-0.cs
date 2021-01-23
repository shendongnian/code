    static int FindMatch(string text, string pattern)
        {
            var total = 0;           
            for (int i = 0; i < pattern.Length; i++)
            {
                var max = 0;               
                for (int j = 2; j <= pattern.Length - i; j++)
                {
                    var temp = pattern.Substring(i, j);
                    if (text.Contains(temp))                   
                        if (max < temp.Length)                        
                            max = temp.Length; 
                }
                total += max;
                if (max > 0)
                    i += max-1;
            }
            return total;
        }
