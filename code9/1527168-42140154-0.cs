    string[] lines = System.IO.File.ReadAllLines("File.xls");
    foreach(string line in lines)
    {
        if((line).Trim().StartsWith("<xls:value-of"))
        {
            Console.WriteLine(line.Split(new[]{" select=\"", "\"/>"}, StringSplitOptions.RemoveEmptyEntries)[1]);
        }
    }
