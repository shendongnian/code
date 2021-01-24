    public static  IEnumerable<string> Produce()
    {
       string seed = "A";
       int i = 0;
       while (true)
       {
           yield return String.Join("", Enumerable.Repeat(seed, i));                
           if (seed == "Z")
           {
              seed = "A";
              i++;
           }
           else
           {
              seed = ((char)(seed[0]+1)).ToString();
           }
        }
    }
