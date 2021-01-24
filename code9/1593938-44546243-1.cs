    public ActionResult Update(q_product q_product, HttpPostedFileBase upload)
    {    
        ProductData pd;
        var entities = new List<ProductData>();
        PostgreSQLCopyHelper<ProductData> insert = null;
        try
        {
            if(ModelState.IsValid && upload != null)
            {                    
                //uploaded file
                Stream stream = upload.InputStream;
                //need to use BULK INSERT or MULTIPLE INSERT at this point;                    
                //get the properties (columns)
                using (var fdr = new FileDataReader<ProductData>(stream))
                {
                    //get each line on file
                    while ((pd = fdr.ReadLine()) != null)
                    {
                        //map table columns with properties
                        insert = insert ?? new PostgreSQLCopyHelper<ProductData>("public","q_product")
                            .MapUUID("q_guid", x => Guid.NewGuid())
                            .MapText("q_barcode", x => this.pd.barcode)
                            .MapText("q_description", x => this.pd.description)
                            .MapText("q_size", x => pd.size) 
                            .MapInteger("q_stocklevel", x => this.pd.quantity)
                            .MapText("q_vatcode", x => pd.vatCode)  
                            .MapMoney("q_casecost", x => this.pd.cost)
                            .MapMoney("q_sellprice", x => this.pd.price);
                        entities.Add(pd);
                    }
                }
                using (var connection = new NpgsqlConnection("Host=192.168.0.52;Database=tester;Username=test;Password=test"))
                {
                    try
                    {
                        connection.Open();
                        insert.SaveAll(connection, entities);                                    
                        TempData["SuccessMessage"] = "Records Inserted!";
                    }
                    catch (Exception er)
                    {
                        TempData["ErrorMessage"] = er.Message;                                    
                        //TempData["ErrorMessage"] = "Error importing records!";
                    }
                }
                return RedirectToAction("Index");
            }
        }
        catch(DataException error)
        {
            TempData["ErrorMessage"] = "Error importing records!";
            ModelState.AddModelError("", error.Message);
        }
        return RedirectToAction("Index");
    }
