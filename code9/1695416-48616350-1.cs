    List<string> ColumnNamesWithNumericTypes = new List<string> ( );
			foreach (DataGridViewColumn dgvCol in dgv.Columns)
			{
				string columnname = dgvCol.Name;
				bool isnumeric = false;
				foreach (DataGridViewRow row in dgv.Rows)
				{
					if (Regex.IsMatch (row.Cells[columnname].Value , @"^[-]?([-.\d]+?)$"))
						isnumeric = true;
					else
					{
						isnumeric = false;
						break;
					}
				}
				if (isnumeric == true) ColumnNamesWithNumericTypes.Add (columnname);
			}
