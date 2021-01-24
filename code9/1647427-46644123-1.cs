    foreach (GridViewRow row in GridView1.Rows)
            {               
                Image img = (Image)row.FindControl("imgID");
                if (img!=null)
                {
                    img.ImageUrl= (row.Cells[4].Text == "Active") ? "~/Images/Active.jpg" : "~/Images/Inactive.jpg";
                }        
    }
