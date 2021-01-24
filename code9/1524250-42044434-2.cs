    public static  IEnumerable<string> Produce()
    {
        string seed = "A";
        int i = 1;
        int increasingPosition = 0;
        while (true)
        {
            yield return seed;
            if (seed == string.Join("",Enumerable.Repeat('Z', i)))
            {
                i++;                    
                seed = string.Join("", Enumerable.Repeat('A', i));
                increasingPosition = seed.Length - 1;
            }
            else
            {
                seed = seed.Substring(0, increasingPosition) 
                   + ((char)(seed[increasingPosition] + 1)).ToString()
                   + string.Join("", Enumerable.Repeat('Z', seed.Length-increasingPosition-1));
                if (seed[increasingPosition] == 'Z')
                {                        
                    increasingPosition--;                        
                }
            }
        }
    }
