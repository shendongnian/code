    protected void RptRequest_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "AddRequest")
        {
            FileUpload myFileUpload = (FileUpload)e.Item.FindControl("FileUpload");
            if (myFileUpload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(myFileUpload.FileName);
                    myFileUpload.SaveAs(Server.MapPath("~/") + filename);
                    myStatusLabel.Text = "Upload Success";
                }
                catch (Exception ex)
                {
                    myStatusLabel.Text = "Upload Fail" + ex.Message;
                }
            }
            else
            {
            
                myStatusLabel.Text = "myFileUpload Has No File";
            }
        }      
    }
