    protected void Page_Load(object sender, EventArgs e)
    {
    	if (!Page.IsPostBack)
    	{
    		SubjectAdded.DataSource = new[] {
    			new {Id= 1, Subject = "Text 1"  },
    			new {Id= 2, Subject = "Text 2"  },
    		};
    		SubjectAdded.DataBind();
    	}
    }
    
    public void Page_PreRender(object sender, EventArgs e)
    {
    	for (int i = 0; i < SubjectAdded.Items.Count; i++)
    	{
    		string feeTB = ((TextBox)SubjectAdded.Items[i].FindControl("FeeBox")).Text;
    		string subjectNameLb = ((Label)SubjectAdded.Items[i].FindControl("SubjectLbl")).Text;
    
    		Response.Write($"{subjectNameLb}: {feeTB}<br/>");
    	}
    }
