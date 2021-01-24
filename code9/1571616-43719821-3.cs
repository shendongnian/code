    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DownloadMusic")
        {
            //To get title of music
            string Title = string.Empty;
            Label lbltitle = new Label();
            lbltitle = (Label)e.Item.FindControl("title");
            Title = lbltitle.Text;
            //to get path fo music
            string FilePath = string.Empty;
            Image imgfile = new Image();
            imgfile = (Image)e.Item.FindControl("musicimage");
            FilePath = imgfile.ImageUrl;
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.ContentType = "audio/mpeg";
            response.AddHeader("Content-Disposition", "attachment; filename=" + Title + ";");
            response.TransmitFile(FilePath);
            response.Flush();
            response.End();
        }
    }
