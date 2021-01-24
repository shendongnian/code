    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath)) 
        {
            for (int i = 0; i<=Content.Length;i++)
            {
                sw.WriteAsync("this is an example");
            }
        }
