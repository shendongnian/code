	public partial class ApriAllegato : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string pathCompleto = Request.QueryString["pathCompleto"];
			string filename = ''; //Get the file name from the path
			Response.Clear();
			Response.ClearContent();
			Response.ClearHeaders();
			if (pathCompleto.EndsWith(".pdf")) {
				Response.ContentType = "application/pdf; name=" + filename;
			} else {
				Response.ContentType = "application/octet-stream; name=" + filename;
			}
			Response.AddHeader("content-transfer-encoding", "binary");
			Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
			Response.ContentEncoding = System.Text.Encoding.GetEncoding(1251);
			Response.WriteFile(pathCompleto);
			Response.End();
		}
	}
