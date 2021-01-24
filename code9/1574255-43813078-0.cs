    public partial class FormViewDemo : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			rgAssnmtList.DataSource = new[] {
				new {Id= 1, Text = "Text 1"  },
				new {Id= 2, Text = "Text 2"  },
			};
			rgAssnmtList.DataBind();
		}
		protected void rgAssnmtList_SelectedIndexChanged(object sender, EventArgs e)
		{
			var list= new List<dynamic>() {
				new {Id= 1, Text = "Text"  },
				new {Id= 2, Text = "Text"  },
			};
			fvAssnmtDets.DataSource = list;
			fvAssnmtDets.DataBind();
			fvAssnmtDets.FindControl("DeleteButton").Visible = rgAssnmtList.SelectedDataKey.Value.ToString() == "1";
		}
	}
