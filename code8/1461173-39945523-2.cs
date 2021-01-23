    using (System.IO.StreamWriter newfile = new System.IO.StreamWriter(@"asc_files\divfile.txt", true))
    {
        foreach (string inputline in inputfile)
        {
            int count = 0;
            foreach (string measurements in inputline.Split(' '))
            {
                newfile.Write((Convert.ToDouble(measurements) / 6).ToString("F4", CultureInfo.CreateSpecificCulture("en-US")));
                if (++count < 1122)
                {
                    newfile.Write(" ");
                }
            }
            newfile.WriteLine();
        }
    } 
