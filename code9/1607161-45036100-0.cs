    public List<int> IconsColor
    {
        set
        {
            List<int> newIcons = value.Except(iconsColorList).ToList();
            nIconsChanged = newIcons.Count > 0;
            iconsColorList.AddRange(newIcons);
        }
    }
