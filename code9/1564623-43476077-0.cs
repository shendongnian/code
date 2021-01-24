            string uncPath = Path.Combine(@"\\TSTSVR\Users\temp_databaseBackups_000kfkf000", string.Format("{0}-{1}.bak",
                ddlDatabases.SelectedValue, DateTime.Now.ToString("yyyy-MM-dd")));
            //download
            Response.ContentType = "bak";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + ddlDatabases.SelectedValue + "-" + DateTime.Now.ToString("MM-dd-yyyy:hh:mm") + "\"");
            Response.TransmitFile(uncPath);
            Response.End();
