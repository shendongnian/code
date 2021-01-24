        protected void LocationView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string order_no = ((Label)e.Row.FindControl("lblorderno")).Text.Trim();
                string order_line_no = ((Label)e.Row.FindControl("lblline")).Text.Trim();
                string label_no = ((Label)e.Row.FindControl("lbllabelno")).Text.Trim();
                string imagefile = DefaultFileName + LocationDat.Location + @"\" + order_no.Trim().Replace("/", "-") +
                @"\" + order_line_no.Trim() + @"\" + label_no + ".jpg";
                FileUpload rowimageupload = (e.Row.FindControl("imageupload") as FileUpload);
                ImageButton btnimagescan = (e.Row.FindControl("btnimagescan") as ImageButton);
                Button btnstart = (e.Row.FindControl("btnstart") as Button);              
                btnimagescan.OnClientClick = "importClick('" + rowimageupload.ClientID.Trim() + "');return false;";
                rowimageupload.Attributes["onchange"] = "UploadFile();";
                try
                {
                    if (File.Exists(imagefile))
                    {
                        btnimagescan.ImageUrl = "~/Images/completewhite25px.png";
                    }
                }
                catch (Exception Ex)
                {
                    lblstatus.Text = Ex.Message;
                }
                
            }
        }
