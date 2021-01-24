    public void LoadLayout(UltraGrid grd, string layoutName)
    {
        if (File.Exists(layoutName))
            grd.DisplayLayout.LoadFromXml(layoutName, PropertyCategories.All);
    }
