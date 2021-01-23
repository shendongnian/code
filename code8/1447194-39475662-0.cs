            for (int y = 0; y < Field.GetLength(0); y++)
            {
                for (int x = 0; x < Field.GetLength(1); x++)
                {
                   if(Feld[Zahler] == "1")
                   {
                      Field[x, y].BackColor = Color.Black;
                   }
                   Zahler++;
                    if (Feld[Zahler] == "1")
                    {
                      Block_Property[x, y] = 1;
                    }
                     Zahler++;
                }
            }
