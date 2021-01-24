        using (var sw = new System.IO.StreamWriter(@"C:\bd.txt"))
        {
            for (int i = 0; i <= allnum; i++)
            {
                sw.WriteLine(titles[i] + i);
                Console.WriteLine(titles[i] + i);
            }
        }
