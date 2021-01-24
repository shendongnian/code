        List<Color> ColorsList = new List<Color>();
        private Color GetRandomColor(Random randomGen)
                {
                    Color randomColor = Color.Red;
                    KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                    KnownColor[] badColors = { KnownColor.AliceBlue };            
                    IEnumerable<KnownColor> colors = names.Except(badColors);
                    colors = colors.ToArray().Except(ColorsList.Select(x => x.ToKnownColor()));
                    KnownColor[] okColors = colors.ToArray();
                    KnownColor randomColorName = okColors[randomGen.Next(okColors.Length)];
                    randomColor = Color.FromKnownColor(randomColorName);
        
                    if (!ColorsList.Contains(randomColor))
                    {
                        ColorsList.Add(randomColor);
                        if (okColors.Count() == 1)
                        {
                            ColorsList.Clear();
                        }
                    }
                    else
                    {
                        GetRandomColor(randomGen);
                    }
        
                    return randomColor;
                }
