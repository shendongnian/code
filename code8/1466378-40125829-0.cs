    string[] zipcodes = strzipcode.Split(',');
    List<string> filterList = new List<string>();
    filterList.Add(txtZipCode.Text.Trim());
    for (int x = 0; x < zipcodes.Length-1; x++)
    {
        filterList.Add(zipcodes[x]);
    }
    var filteredFileSet = dealers.Where(i => filterList.Contains(i.ZipCode));
    dtlSanPham.DataSource = filteredFileSet.ToList();
    dtlSanPham.DataBind();
