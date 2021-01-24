    public void SaveLayout(UltraGrid grd, string layoutFile)
    {
        if (grd.DataSource != null)
            grd.DisplayLayout.SaveAsXml(layoutFile, PropertyCategories.All);
    }
