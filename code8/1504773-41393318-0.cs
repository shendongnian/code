    var test = JsonConvert.DeserializeObject<RootObject>(json);
    DataTable dt = new DataTable();
    dt.Columns.Add("NameOfGamingEquipment");
    dt.Columns.Add("ResourceId");
    dt.Columns.Add("RentalPrice");
    // Add more columns
    foreach (var item in test.Portable)
    {
        var row = dt.NewRow();
        row["NameOfGamingEquipment"] = item.NameOfGamingEquipments;
        row["ResourceId"] = Convert.ToString(item.ResourceId);
        row["RentalPrice"] = item.RentalPrice;
        dt.Rows.Add(row);
    }
