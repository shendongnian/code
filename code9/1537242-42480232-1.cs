    HttpPostedFile userPostedFile;
    string filepath = Server.MapPath("\\Upload");
    HttpFileCollection uploadedFiles = Request.Files;
    Span1.Text = string.Empty;
    public void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < uploadedFiles.Count; i++)
        {
            userPostedFile = uploadedFiles[i];
