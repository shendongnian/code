	System.Text.StringBuilder csv = new System.Text.StringBuilder();						
	String separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
	List<String> listProperties = new List<string>();
	csv.AppendLine("sep=" + separator);
	foreach (System.Windows.Controls.GridViewColumn col in myGridView.Columns)
	{
		// Check if column is displayed
		if (col.ActualWidth > 0)
		{
			// Get Header value
			string header = col.Header as String;
			
			//Check if Header is not empty
			if (!String.IsNullOrWhiteSpace(header))
			{
				// Write in firte line
				csv.Append(header + separator);
				
				// Get if columns is binding a property
				System.Windows.Data.Binding binding = col.DisplayMemberBinding as System.Windows.Data.Binding;
				if (binding != null)
				{
					// Get the name of property
					listProperties.Add(binding.Path.Path);
				}
			}
		}
	}
	// Write first line
	csv.AppendLine();
	
	foreach (myItem item in myListView.Items)
	{
		foreach (String property in listProperties)
		{
			// Get and write value for property
			object value = GetPropValue(item, property);
			csv.Append(value + separator);
		}
		csv.AppendLine();
	}
	System.IO.File.WriteAllText(path, csv.ToString());
	
	
	
	public static object GetPropValue(object src, string propName)
	{
		return src.GetType().GetProperty(propName).GetValue(src, null);
	}
