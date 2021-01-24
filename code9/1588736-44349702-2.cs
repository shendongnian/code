    static void Permutations(List<string> output, string str, int n, string curr)
        {
            if(curr.Length == n)
            {
                output.Add(curr);
                return;
            }
            foreach(char c in str)
                if(!curr.Contains(c.ToString()))
                    Permutations(output, str, n, curr + c.ToString());
        }
