    var json = File.ReadAllText(@"C:\Path\json.txt");
    var test = JsonConvert.DeserializeObject<RootObject>(json);
    DataTable dt = new DataTable();
    dt.Columns.Add("NameOfGamingEquipment");
    dt.Columns.Add("ResourceId");
    dt.Columns.Add("RentalPrice");
    dt.Columns.Add("DeliveryMode");
    dt.Columns.Add("QuantityOfCables");
    dt.Columns.Add("TypeOfCable");
    dt.Columns.Add("Accessories");
    foreach (var item in test.Non_Portable)
    {
        var row = dt.NewRow();
        row["NameOfGamingEquipment"] = item.NameOfGamingEquipments;
        row["ResourceId"] = Convert.ToString(item.ResourceId);
        row["RentalPrice"] = item.RentalPrice;
        row["DeliveryMode"] = item.DeliveryMode;
        row["quantityOfCables"] = item.quantityOfCables;
        row["TypeOfCable"] = item.TypeOfCable;
        row["Accessories"] = item.Accessories;
        dt.Rows.Add(row);
    }
    this.GridView1.DataSource = dt;
    this.GridView1.DataBind();
