    // create a new JObject by grouping the data table rows by block and then
    // selecting the groups into JProperties where the block is the property name
    // and the property value is a JArray containing the house numbers in the group
    var obj = new JObject(
        dataTable.Rows.Cast<DataRow>()
                      .GroupBy(r => r["Block"])
                      .Select(g => new JProperty(
                          "Block " + g.Key, 
                          new JArray(g.Select(r => r["HouseNo"]))
                      ))
    );
    // convert the JObject to a JSON string
    var json = obj.ToString();
