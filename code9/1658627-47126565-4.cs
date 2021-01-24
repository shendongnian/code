	using TableDAO = MyApplication.DAO.TableDAO;
	public partial class MyPage : System.Web.UI.Page
	{
		protected string TableGradientCss { get; set; }
		
		protected void Page_Load(object sender, EventArgs e)
		{
			BindClients();
		}
		
		public void BindClients()
		{
			var dao = new TableDAO();
			var clientTable = dao.GetClients();
			gvDados.DataSource = clientTable;
			gvDados.DataBind();
			ExtractClientsGradientCss(clientTable);
		}
		
		protected void gvDados_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			var label = e.Row.FindControl("gradClass") as Label;
			if (label != null)
			{
				e.Row.CssClass = label.Text;
			}
		}
		
		private void ExtractClientsGradientCss(DataTable clients)
		{
			var sb = new StringBuilder();
			foreach(DataRow row in clients.Rows)
			{
				sb.Append(
					GetGradientCss(
						row["gradClass"].ToString(),
						row["gradientParams"].ToString()));
			}
			TableGradientCss = sb.ToString();
		}
		
		private string GetGradientCss(string className, string gradientParams)
		{
			var css = @"
			.{0} {{
				background: white;                          /* For browsers that do not support gradients */
				background: -webkit-linear-gradient({1});   /*Safari 5.1-6*/
				background: -o-linear-gradient({1});        /*Opera 11.1-12*/
				background: -moz-linear-gradient({1});      /*Fx 3.6-15*/
				background: linear-gradient({1});           /*Standard*/
			}} ";
			return string.Format(css, className, gradientParams);
		}
	}
