    protected void Page_Load(object sender, EventArgs e)
            {
			    var sqlData;
			    using (SqlDataDataContext ctx = new SqlDataDataContext(ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString))
			{
				sqlData = ctx.GetCurrentData();
			}
            StringBuilder sbJs = new StringBuilder();
			sbJs.AppendLine(@"var sqlData = new Array();");
			int i = 0;
			foreach(var sqlRow in sqlData)
			{
				sbJs.AppendLine(String.Format("sqlData.push({id:{0}, latitude:{1}, longitude:{2}, status:{3}});", sqlRow.Id, sqlRow.latitude , sqlRow.longitude, sqlRow.status);
			}
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "DynamicScript", sbJs.ToString(), true);
        }
