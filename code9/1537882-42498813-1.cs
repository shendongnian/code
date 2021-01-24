    DataTable dt = new DataTable();
    dt.Columns.Add("FileName");
    dt.Columns.Add("Order");
    
    foreach (var image in viewmodel.Images)
    {
        dt.Rows.Add(image.FileName, image.Order);
    }
    
    var param = new DynamicParameters();
    param.Add("@Images", dt);//TVP
    param.Add("@GalleryName", model.GalleryName);
    param.Add("@Category", model.Category);
    
    connection.Execute("CreateGallery", param, commandType: CommandType.StoredProcedure);
