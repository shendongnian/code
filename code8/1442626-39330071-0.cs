	location = int.Parse(txtLocation.Text);
	name = Convert.ToString(txtName.Text);
	string[] strOriginalNames = new[] { "John", "Paul", "Rodney", "David", "Kathryn" };
	lblOriginalNames.Text = String.Join("<br>", strOriginalNames);
	strOriginalNames[location] = name;
	lblNewNames.Text = String.Join("<br>", strOriginalNames);
