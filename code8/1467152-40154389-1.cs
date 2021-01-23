    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UploadFile(sender, e);
            }
          
        }
        protected void UploadFile(object sender, EventArgs e)
        {
            try
            {
                HttpFileCollection fileCollection = Request.Files;
                string savedfile = "";
                for (int i = 0; i < fileCollection.Count; i++)
                {
                    try
                    {
                        HttpPostedFile upload = fileCollection[i];
                        int f = fileCollection[i].ContentLength;
                        string filename = "/ProductImages/" + fileCollection[i].FileName;
                        upload.SaveAs(Server.MapPath(filename));
                        savedfile += fileCollection[i].FileName;
                    }
                    catch (Exception ex)
                    {
                       
                    }
                }
            }
            catch(Exception ex)
            {
                List<string> ff = new List<string>();
                ff.Add(ex.Message.ToString());
                System.IO.File.WriteAllLines(Server.MapPath("/ProductImages/Error.txt"), ff);
            }
           
        }
    }
