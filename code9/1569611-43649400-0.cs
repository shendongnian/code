    private void ClassifyData()
            {
                double dblValue = 0;
                foreach (var item in RandomData)
                {
                    if (double.TryParse(item, out dblValue))
                    {
                        dblList.Add(dblValue);
                    }
                    else if (CheckColor(item))
                    {
                        ColorList.Add(item);
                    }
                    else
                    {
                        MetalList.Add(item);
                    }
                }
            }
    
            private bool CheckColor(string colorName)
            {
                Color c = Color.FromName(colorName);
                if (c.IsKnownColor)
                    return true;
                return false;
            }
