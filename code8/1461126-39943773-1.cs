    byte[] bytes = System.Text.Encoding.ASCII.GetBytes("abcd".ToCharArray());
    
    for (int i = 0; i <= bytes.GetUpperBound(0); i++)
    {
        bytes[i]++;
    }
    
    Console.WriteLine(System.Text.Encoding.ASCII.GetString(bytes));
