<div>
	@using (Html.BeginForm()) {
		<input name="pleaseWork" type="text" />
		<button asp-page-handler="DoWork">search</button>
	}
</div>
Then in your [PageModel].cshtml.cs file...
public void OnPostDoWork() {
	var inpString = HttpContext.Request.Form["pleaseWork"];
	string sql = "SELECT * FROM Table WHERE (ID = '" + inpString + "')";
	SqlConnection connect = new SqlConnection(Connection);
	SqlCommand command = new SqlCommand(sql, connect);
	conn.Open();
	SqlDataReader nwReader = command.ExecuteReader();
	/*...Display results*/
}
Note: I'm currently using asp .net core 2.1
