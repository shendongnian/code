    protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
	{
		// Get the property object based on the DataPropertyName of the column
		var property = typeof(SyncDetail).GetProperty(e.Column.DataPropertyName);
		// Get the ColumnWeight attribute from the property if it exists
		var weightAttribute = (ColumnWeight)property.GetCustomAttribute(typeof(ColumnWeight));
		if (weightAttribute != null)
		{
			// Finally, set the FillWeight of the column to our defined weight in the attribute
			e.Column.FillWeight = weightAttribute.Weight;
		}
		base.OnColumnAdded(e);
	}
