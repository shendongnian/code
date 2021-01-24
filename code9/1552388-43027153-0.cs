    // Copy the contents of the listbox into a string array
	string[] filenameList = listBox1.Items.OfType<string>().ToArray();
	try
	{
		for (int i = 0; i < filenameList.Length; i++)
		{
			string filename = filenameList[i];
			if (File.Exists(filename))
			{
				File.Delete(filename);
				listBox1.Items.Remove(filename);
			}
		}
	}
	catch (Exception)
	{
	}
