    for (int y = 0; y < 4; y++)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        if (Feld[Zahler] == "1")
                        {
                            Field[y, x].BackColor = Color.Black;
                        }
                        Zahler++;
                        if (Feld[Zahler] == "1")
                        {
                            Block_Property[y, x] = 1;
                        }
                        Zahler++;
                    }
                }
