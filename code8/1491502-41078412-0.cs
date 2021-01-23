            AcadAcCmColor color = new AcadAcCmColor();
            int index = 0;
            if (colorName.ToUpper() == "BYBLOCK")
            {
                color.ColorIndex = AcColor.acByBlock;
            }
            else if (colorName.ToUpper() == "BYLAYER")
            {
                color.ColorIndex = AcColor.acByLayer;
            }
            else if (int.TryParse(colorName, out index))
            {
                color.ColorIndex = (AcColor)index;
            }
            else if (colorName.ToUpper().StartsWith("RGB:"))
            {
                string[] rgb = colorName.Substring(4).Split(',');
                color.SetRGB(int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2]));
            }
            else
            {
                string[] bookColor = colorName.Split('$');
                color.SetColorBookColor(bookColor[0], bookColor[1]);
            }
