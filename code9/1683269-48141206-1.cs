    // Create a new JObject by grouping the data table rows by block and then
    // selecting the groups into JProperties where the block is the property name
    // and the property value is a JArray containing JObjects with the resident IDs 
    // and corresponding house numbers in the group making up the properties of those. 
    var obj = new JObject(
        table.Rows.Cast<DataRow>()
             .GroupBy(r => r["Block"])
             .Select(g => new JProperty("Block " + g.Key,
                 new JArray(g.Select(r =>
                     new JObject(
                         new JProperty(r["ResidentId"].ToString(), r["HouseNo"])
                     )
                 ))
             ))
    );
    // Convert the JObject to a JSON string
    var json = obj.ToString();
