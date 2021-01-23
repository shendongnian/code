	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string searchName = "";
			if (SearchTextBox.Text != "") //if (this.GetPostBackControlUniqueID() == Search.UniqueID) //Search button is clicked! 
			{
				searchName = SearchTextBox.Text;
			}
			addTable(searchName);
		}
		void addTable(string searchName)
		{
			string[] data = new[] { 
				 "John, false, usrJohn"
				,"Alex, false, usrAlex"
				,"Ali,  true,  usrAli" 
			};
			//using (OleDbDataReader reader = cmd.ExecuteReader())
			//{
				Table table = new Table(); table.CellPadding = 10;
				TableRow row;
				TableCell cell;
				Label label;
				
				foreach(string dataItem in data) //while (reader.Read())
				{
					string[] reader = dataItem.Split(',');
					if (reader[0].IndexOf(searchName, StringComparison.OrdinalIgnoreCase) < 0) continue; //search not found (in real app, you use sql where clause for this, but this is just for test)
					
					row = new TableRow();
					cell = new TableCell();
					label = new Label();
					label.Text = reader[0].Trim(); //reader.GetString(0);
					cell.Controls.Add(label);
					cell.BorderStyle = BorderStyle.Solid;
					row.Cells.Add(cell);
					cell = new TableCell();
					label = new Label();
					label.Text = reader[1].Trim(); //reader.GetBoolean(1).ToString();
					cell.Controls.Add(label);
					cell.BorderStyle = BorderStyle.Solid;
					row.Cells.Add(cell);
					cell = new TableCell();
					LinkButton button = new LinkButton();
					button.Text = "Delete";
					string uName = reader[2].Trim();
					button.ID = uName; //(string)reader["uName"];
					button.CommandName = uName; //(string)reader["uName"];
					button.Click += new EventHandler(DeleteUser);
					cell.Controls.Add(button);
					cell.BorderStyle = BorderStyle.Solid;
					row.Cells.Add(cell);
					table.Rows.Add(row);
				}
				table.Style.Add(HtmlTextWriterStyle.MarginLeft, "auto");
				table.Style.Add(HtmlTextWriterStyle.MarginRight, "auto");
				TableHolder.Controls.Add(table);
			//} //end using OleDbDataReader reader
		}
		protected void Search_Click(object sender, EventArgs e)
		{
			//addTable(SearchTextBox.Text); //already done in Page_Load
		}
		protected void DeleteUser(object sender, EventArgs e)
		{
			LinkButton button = (LinkButton)sender;
			//using (OleDbCommand cmd = new OleDbCommand("DELETE * FROM ArcadeDatabase WHERE uName ='" + button.CommandName + "';", con))
			string sql = "DELETE * FROM ArcadeDatabase WHERE uName ='" + button.CommandName + "';";
			//execute the sql ... (in real app)
			TableHolder.Controls.Add(new LiteralControl("The sql was: " + sql));
		}
		protected void Button1_Click(object sender, EventArgs e)
		{
			Label1.Text = DateTime.Now.ToString("HH:mm:ss");
		}
	} //end class
