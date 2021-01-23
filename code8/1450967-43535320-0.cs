    ****on click of the button you can dowload the excel****       
    
     protected void btn_download_template(object sender, EventArgs e)
            {
                string str_FolderPath = "c:/Budget_Sample.xlsx";
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(str_FolderPath));
                Response.WriteFile(str_FolderPath);
                Response.End();
            }
