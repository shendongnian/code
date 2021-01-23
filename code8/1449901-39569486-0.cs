    using (StreamWriter SW = new StreamWriter(@"txt.txt"))
    {
        // the loops creating the .txt-file.
        for (int i = 0; i < M.GetLength(0); i++)
        {
            for (int a = 0; a < 13; a++)
            {
                SW.Write(" " + M[i][a]);
            }
            //SW.WriteLine(M); // <-- this line was generating your output
            SW.WriteLine("");
        }
    }
