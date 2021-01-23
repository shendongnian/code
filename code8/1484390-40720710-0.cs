    string[] lines = File.ReadAllLines("C:/temp/test.txt");
            int sizex = lines.Length;
            int sizey = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                var splitline = lines[i].Split(' ');
                foreach (var s in splitline)
                {
                    sizey = sizey < splitline.Length ? splitline.Length : sizey;
                }                
            }
            
            String[,] multillines = new string[sizex,sizey];
            for (int i = 0; i < lines.Length; i++)
            {
                var splitline = lines[i].Split(' ');
                for (int j = 0; j < splitline.Length; j++)
                {
                    multillines[i, j] = splitline[j];
                }
            }
