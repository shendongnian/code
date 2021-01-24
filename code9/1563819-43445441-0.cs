	private string GuestA;
	private string GuestB;
	private string GuestC;
	private void button1_Click(object sender, EventArgs e)
	{
		string variableName;
		string[] values = {"Joe", "Ben", "Carl" };
		for(int i = 0; i < values.Length; i++)
		{
			variableName = "Guest" + Convert.ToChar(65 + i).ToString();
			System.Reflection.FieldInfo fi = this.GetType().GetField(variableName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
			if (fi != null)
			{
				fi.SetValue(this, values[i]);
			}
		}
	}
