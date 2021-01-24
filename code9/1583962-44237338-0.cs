        public ActionResult LoadContent()
        {
              
        dynamic expando = new ExpandoObject();
        var model = expando as IDictionary<string, object>;
        
            
        /*Let say user insert the detail of employee registration form. Make the     
        database call and get the distinct detail of particular inserted form by Id   
        or whatever. As an example below datatable contains the data that you fetch  
        during database call.*/
                        
            
        DataTable objListResult =    
        HeaderViewActionHelper.GetFinalResultToRenderInGenericList(id);
            
            
        if (objListResult != null && objListResult.Rows.Count > 0)
        {
          foreach (DataRow row in objListResult.Rows)
          {
            model.Add(row["DisplayName"].ToString(),    
            row["DisplayNameValue"].ToString());
                  
        /*If you want to handle the datatype of each field than you can bifurcation   
        the type here using If..else or switch..case. For that you need to return   
        another column in your result from database i.e. DataType coloumn. Add in   
        your model as, model.Add(row["DisplayName"].ToString(),   
        row["DisplayNameValue"].ToString(), row["DataType"].ToString());*/
          }
       }
            
        /* return the model in view. */
        return View(model);
        }
