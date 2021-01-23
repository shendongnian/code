    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DisplayDirectoryContent(Server.MapPath("~"));
        }
    }
    void DisplayDirectoryContent(string directory)
    {
        System.Data.DataTable data = new System.Data.DataTable();
        data.Columns.Add("Name",typeof(string));
        data.Columns.Add("IsFolder", typeof(bool));
        foreach (var dir in System.IO.Directory.GetDirectories(directory))
        {
           System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(directory);
           data.Rows.Add(new object[] { di.Name, true });
        }
        foreach (var file in System.IO.Directory.GetFiles(directory))
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(file);
            data.Rows.Add(new object[] { fi.Name, false });
        }
        GridView1.DataSource = data;
        GridView1.DataBind();
    }
