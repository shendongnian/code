    public void VendorsDictionary_Load(object sender, EventArgs e)
    {
        var vendors = LoadVendors();
        foreach (var thisVendor in vendors)
        {
            vendorPhones.Add(thisVendor.Name, thisVendor.Phone);
            lvDisplay.Items
                .Add(new ListViewItem(new[] { thisVendor.Name, thisVendor.City,
                    thisVendor.State, thisVendor.ZipCode }));
        }
    }
