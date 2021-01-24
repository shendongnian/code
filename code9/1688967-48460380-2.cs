        public void FindUpload(object sender, EventArgs e)
        {
            if (Session["package"] != null)
            {
                foreach (GridViewRow row in LocationView.Rows)
                {
                    FileUpload file = ((FileUpload)row.FindControl("imageupload"));
                    if (file != null)
                    {
                        if (file.HasFile)
                        {
                            Upload(file, row);
                        }
                    }
                }
            }
        }
