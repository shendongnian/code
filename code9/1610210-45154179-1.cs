    try
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\user_pc\Desktop\test.txt"))
        {
            double number = 0;
            do
            {
                number += 0.000000000000000000000000000001;
                file.WriteLine(number.ToString("N30"));
            } while (number <= 0.999999999999999999999999999999);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
