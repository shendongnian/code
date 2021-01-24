    static void Main(string[] args) 
    {
        int con = 0;
        for (int i = 0; i < 512; i++)
        {
            string test = Convert.ToString(i, 2);
            int count = test.Split('1').Length - 1;
            if (count == 3)
            {
                con++;
            }
        }
        Console.WriteLine(con);
    }
