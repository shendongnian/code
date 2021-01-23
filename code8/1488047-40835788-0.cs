    for (int i = 0; i < linecount; i++)
    {
        string[] b = sr.ReadLine().Split(' ');
        for (int j = 0; j < b.Length; j++)
        {
                        
            try
            {
                a[i, j] = float.Parse(b[j]);
            }
            catch (FormatException ex)
            {
                var notANumber = b[j];
            }
            
        }
    }
