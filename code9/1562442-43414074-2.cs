	public class DataBase
		{
		    [BsonId]
		    public string GetSetVariable { get; set; }
		}
	private void DisplayData_Load(object sender, EventArgs e)
	{
		using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
		{
			// Get a collection (or create, if doesn't exist)
			var col = db.GetCollection<DataBase>("collection_name");
			// Enter data into the database
			var incomingData = new Database
			{ 
				GetSetvariable = "This is output text."
			};
			// Create unique index in Name field
			col.EnsureIndex(x => x.GetSetVariable, true);
			// Insert new customer document (Id will be auto-incremented)
			col.Insert(incomingData);
			// Update a document inside a collection
			incomingData.GetSetVariable = "Updated Text Record";
			col.Update(incomingData);
			// Create a query
			var results = col.FindAll();
			// To display ALL columns of 'results' in a combo box.
			foreach (var finding in results)
			{
				var variable = finding.GetSetVariable;
				comboBox1.Items.Add(variable);
				Console.WriteLine(variable);
			}
			// To display one record of 'results' to a text box.
			var query = col.FindById(1);
			var variable = query.GetSetVariable;
            textBox1.Text = variable;
			Console.WriteLine(variable);
		}
	}
