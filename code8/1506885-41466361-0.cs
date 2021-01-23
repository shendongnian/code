    public static void SplitQuadKey(string quadKey, int zoom)
            {
                if (quadKey.Length < zoom)
                {
                    for (int j = 0; j <= 3; j++)
                    {
                        Console.WriteLine(quadKey + j);
                        SplitQuadKey(quadKey + j, zoom);
                    }
                }
            }
