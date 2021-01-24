    Random r = new Random();
    int occurrences = r.Next(1, 35);
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < occurrences; i++)
    {
         sb.Append('=');
    }
                
    string output = sb.ToString();
                
    Console.WriteLine(output);
