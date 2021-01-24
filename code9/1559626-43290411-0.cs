	List<string> users = new List<string>(File.ReadAllLines(pathtouser));
	List<string> passwords = new List<string>(File.ReadAllLines(pathtopass));
	int index = users.IndexOf(Usertext.Text);
	if (index != -1 && index < passwords.Count)
	{
		if (passtext.Text == passwords[index])
		{
			testing test = new testing();
			test.Show();
			return;
		}
	}
	else
	{
		MessageBox.Show("User or password is incorrect. Please verify!!", "WARNING!!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}
