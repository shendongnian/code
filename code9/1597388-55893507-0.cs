private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
{
	try
	{
		Enum.TryParse(colorComboBox.Text, out MetroColorStyle color);
		this.Style = color;
	}
	catch (ArgumentException)
	{
		this.Style = MetroColorStyle.Default;
	}
	Refresh();
}
