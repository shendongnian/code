     int x = int.Parse(ProdBOOStatusBarColor);
                string colorHex = x.ToString("X6");
                StringBuilder color = new StringBuilder();
                color.Append("#");
                color.Append(colorHex.Substring(4, 2));
                color.Append(colorHex.Substring(2, 2));
                color.Append(colorHex.Substring(0, 2));
                color.ToString();
