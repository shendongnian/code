    protected void Page_Load(object sender, EventArgs e)
    {
        //check if the file exists and show
        if (File.Exists(Server.MapPath("testImage.jpg")))
        {
            setImage("/testImage.jpg");
        }
    }
    //upload a new image
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
                FileUpload1.SaveAs(Server.MapPath("testImage.jpg"));
                setImage("/testImage.jpg");
            }
            catch
            {
                //error writing file
            }
        }
    }
    //delete the image
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            File.Delete(Server.MapPath("testImage.jpg"));
            LinkButton1.Visible = false;
            Image1.Visible = false;
        }
        catch
        {
            //error deleteing file
        }
    }
    //set the image and show the delete link
    private void setImage(string image)
    {
        Image1.ImageUrl = "/testImage.jpg";
        Image1.Visible = true;
        LinkButton1.Visible = true;
    }
