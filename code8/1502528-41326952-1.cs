    public class StringBooleanCellEditor : ComboBox
	{
		public StringBooleanCellEditor()
		{
			DropDownStyle = ComboBoxStyle.DropDownList;
			ValueMember = "Key";
			var values = new ArrayList
				{
					new ComboBoxItem("False", "Ложь"),
					new ComboBoxItem("True", "Истина")
				};
			DataSource = values;
		}
	}
