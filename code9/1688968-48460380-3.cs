        public void Upload(FileUpload file, GridViewRow gvr)
        {
            FileUpload fileupload = file;
            UploadResize fileUpld = new UploadResize(1024, 768, System.Drawing.Color.Black);
            PackLabel labelClicked = new PackLabel();
            labelClicked.order_no = ((Label)gvr.FindControl("lblorderno")).Text.Trim();
            labelClicked.order_line_no = ((Label)gvr.FindControl("lblline")).Text.Trim();
            labelClicked.label_no = Convert.ToInt32(((Label)gvr.FindControl("lbllabelno")).Text.Trim());
            labelClicked.product = ((Label)gvr.FindControl("lblproduct")).Text.Trim();
            labelClicked.pack_qty = Convert.ToInt32(((Label)gvr.FindControl("lblcqty")).Text.Trim());
            var btnImageScan = (ImageButton)gvr.FindControl("btnimagescan");
            fileUpld.Upload(fileupload,txtlocation.Text.Trim(),labelClicked);
            if (!fileUpld.IsUploaded)
            {
                lblstatus.Text = fileUpld.UploadError;
            }
            else
            {
                btnImageScan.ImageUrl = "~/Images/completewhite25px.png";
            }
        }
