    ds.Tables.Add(SubtoSubCategoryTable);
    
    //add relations to the tables here
    ds.Relations.Add("CatSubCat", CategoryTable.Columns["CatID"], SubCategoryTable.Columns["CatID"]);
    ds.Relations["CatSubCat"].Nested = true;
    ds.Relations.Add("SubCatSubSubCat", SubCategoryTable.Columns["SubID"], SubtoSubCategoryTable.Columns["SubID"]);
    ds.Relations["SubCatSubSubCat"].Nested = true;
    //call the writexml overload with WriteSchema to save the contents with schema
    ds.WriteXml(Server.MapPath("~/") + "Product.xml", XmlWriteMode.WriteSchema);
