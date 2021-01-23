Where(i => filterList.Contains(i.ZipCode.ToString()));
    string[] zipcodes = strzipcode.Split(',');
    List<string> filterList = new List<string>();
    filterList.Add(txtZipCode.Text.Trim());
    zipcodes.ForEach(zipCode => {
      filterList.Add(zipCode);
    })
    var filteredFileSet = dealers.Where(i => filterList.Contains(i.ZipCode.Value));
    dtlSanPham.DataSource = filteredFileSet.ToList();
    dtlSanPham.DataBind();
