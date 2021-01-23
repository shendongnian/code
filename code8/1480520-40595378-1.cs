    string ln = string.Empty;
    int c = 0;
    using (StreamReader dr = new StreamReader(@"C:\Users\Venkatesh\Desktop\sample.txt"))
    {
        while (ln != null)
        {
            ln = dr.ReadLine();
            c += 1; 
            if (c%2 == 0){
                using (StreamWriter even = new StreamWriter(@"C:\even.txt"))
                {
                    even.WriteLine(ln);
                }
            }
            else {
                using (StreamWriter even = new StreamWriter(@"C:\even.txt"))
                {
                odd.WriteLine(ln);
                }
            }
        }
    }
