    ds = objBLL.FetchInventoryDetails(objBE);
    if(ds.Tables.Count > 0)
    {                
    if(ds.Tables[0].Rows.Count > 0)
    {
    if (ds.Tables[0].Rows[0][0].ToString() == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),      "check", "alert('The JOB is already mapped. Please check');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),  "saved", "alert('Saved Successfully');", true);
                    clearControls();
                }
    }
    }
