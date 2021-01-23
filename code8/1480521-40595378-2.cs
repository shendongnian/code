    string ln = string.Empty;
    int c = 0;
    using (StreamWriter odd = new StreamWriter(@"C:\Users\rdaniel\Desktop\odd.txt"))
    using (StreamWriter even = new StreamWriter(@"C:\Users\rdaniel\Desktop\even.txt"))
    using (StreamReader dr = new StreamReader(@"C:\Users\rdaniel\Desktop\example.txt"))
    {
        while (ln != null)
        {
            ln = dr.ReadLine();
            c += 1;
            if (c % 2 == 0)
            {
                even.WriteLine(ln);
            }
            else
            {
                odd.WriteLine(ln);
            }
        }
    }
