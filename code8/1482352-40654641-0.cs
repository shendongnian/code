    protected void Page_Load(object sender, EventArgs e)
    {
       if(!IsPostBack)
       {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            var path = Server.MapPath("ProjectsImages/ ");
            var images = Directory.GetFiles(path,id+"*");
            ArrayList list = new ArrayList();
            foreach (var img in images)
            {
               list.Add(img);
           }
           RepaterImages.DataSource = images;
           RepaterImages.DataBind();
	    }
    }
