	DataGridViewColumn GetColumn(string type)
	{
		switch (type)
		{
			case "DataGridViewTextBoxColumn":
				return new DataGridViewTextBoxColumn();
			case "DataGridViewComboBoxColumn":
				return new DataGridViewComboBoxColumn();
            //case XYZ: return XYZ
			default:
				return null;
		}
	}
