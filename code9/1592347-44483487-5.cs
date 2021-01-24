        private void Highlight()
        {
            foreach (TokenExtent ext in BasicEnvironment.TokenExtents)
            {
                switch (ext.Name)
                {
                    case "ID" :
                    {
                        etCode2.Select(ext.Start, ext.Length);
                        etCode2.SelectionColor = Color.Blue;
                        break;
                    }
                    case "COMMENT" :
                    {
                        etCode2.Select(ext.Start, ext.Length);
                        etCode2.SelectionColor = Color.DimGray;
                        break;
                    }
                    case "WS":
                    {
                        etCode2.Select(ext.Start, ext.Length);
                        etCode2.SelectionBackColor = Color.BurlyWood;
                        break;
                    }
                }
            }
        }
