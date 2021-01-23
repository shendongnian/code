    byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes("abcd".ToCharArray());
    
    for (int i = 0; i <= bytes.GetUpperBound(0); i++)
    {
        bytes[i]++;
    }
    
    Console.WriteLine(System.Text.ASCIIEncoding.ASCII.GetString(bytes));
