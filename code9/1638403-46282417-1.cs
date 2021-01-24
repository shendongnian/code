	using System;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	public partial class Test : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			txtBox.Text = "Page_Loaded";
		}
		protected void btnSave_Click(object sender, EventArgs e)
		{
			txtBox.Text += "\n" + DateTime.Now.ToString("mm:ss:fff");
		}
        protected void Page_PreRenderComplete(object sender, EventArgs e)
		{
			txtBox.Text += "\nPreRenderComplete";
		}
	}
