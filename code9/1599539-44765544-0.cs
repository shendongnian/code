    using Microsoft.VisualBasic.FileIO;
    ...
    using (TextFieldParser parser = new TextFieldParser(fname))
    {
				parser.TextFieldType = FieldType.Delimited;
				parser.Delimiters = new string[] { ";" };
				parser.HasFieldsEnclosedInQuotes = false;
				string[] fields = parser.ReadFields();
				dt.Columns.Add(fields[2], typeof(string));
				dt.Columns.Add(fields[4], typeof(decimal));
				while (!parser.EndOfData)
				{
					string[] line = parser.ReadFields();
					DataRow row = dt.NewRow();
					row["#"] = line[2];
					row["Delay"] = Convert.ToDecimal(line[4]);
					dt.Rows.Add(row);
				}
			}
			this.dataGridView1.DataSource = dt;
