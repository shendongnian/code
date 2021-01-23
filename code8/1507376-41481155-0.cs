    DataRow row = dt_ProductName.AsEnumerable()
        .FirstOrDefault(r => r.Field<string>("ProductName") == Model_Names);
    decimal Model_ID = -1;
    if(row != null && decimal.TryParse(row.Field<string>("ProductId"), out Model_ID))
    {
        Console.WriteLine($"Product {Model_Names} found, ProductId = {Model_ID}");
    }
