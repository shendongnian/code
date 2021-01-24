    public List<int> IconsColor
    {
        set
        {
            for (int i = 0; i < Math.Min(iconsColorList.Count, value.Count); i++)
            {
                if (value[i] != iconsColorList[i])
                {
                    iconsColorList[i] = value[i];
                    nIconsChanged = true;
                }
            }
            if (value.Count > iconsColorList.Count)
            {
                // append new items to the end of the list
                iconsColorList.AddRange(value.Skip(iconsColorList.Count));
                nIconsChanged = true;
            }
        }
    }
