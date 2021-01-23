    Dataset dsReturnedObj = db.checkExistingPDF(fileName)
    if (dsReturnedObj != null)
    {
         if (dsReturnedObj.Tables.Count > 0)
         {
             if (dsReturnedObj.Tables[0].Rows.Count > 0)
             {
                 this.FileUpload1.SaveAs(Path.Combine(svrPath, fileName + ".pdf"));
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", " alert('Successfully uploaded');", true);
             }
         }
    }
    
