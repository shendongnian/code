    public void SaveLayout(UltraGrid grd, string layoutName)
    {
        if (grd.DataSource != null)
            grd.DisplayLayout.SaveAsXml(s, PropertyCategories.All);
    }
