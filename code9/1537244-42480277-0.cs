    public partial class _WebForm1 : System.Web.UI.Page
    {
    
    HttpPostedFile userPostedFile;
    
    public void Button1_Click(object sender, EventArgs e)
    {
        string filepath = Server.MapPath("\\Upload");
        HttpFileCollection uploadedFiles = Request.Files;
        Span1.Text = string.Empty;
    
        for (int i = 0; i < uploadedFiles.Count; i++)
        {
            userPostedFile = uploadedFiles[i];
    
            if (userPostedFile.ContentLength > 0)
            {
                userPostedFile.SaveAs(filepath + "\\" + Path.GetFileName(userPostedFile.FileName));
    
                Span1.Text += "Location where saved: " + filepath + "\\" + Path.GetFileName(userPostedFile.FileName) + "<p>";
    
            }}}
