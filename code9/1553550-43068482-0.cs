      protected void Page_Load(object sender, EventArgs e)
        	{
        		if (!IsPostBack)
        		{
        			testdiv.InnerHtml = @"<input type=""button"" id=""btnSubmit"" value = ""Click Here"" runat = ""server"" onclick=""__doPostBack('btnSubmit','')""/> ";
        		}
        		else
        		{
        			var eventTarget = Request.Form["__EVENTTARGET"].ToString();
        			if (eventTarget == "btnSubmit")
        			{
        				getdata();
        			}
        		}
        	}
        
        	public string getdata() {
        		Response.Write("clicked.");
        	}
