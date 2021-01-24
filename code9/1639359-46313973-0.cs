    using (var op = new OpenFileDialog())
	{
		if (op.ShowDialog() != DialogResult.OK)
			return;
		using (var stream = System.IO.File.OpenRead(op.FileName))
		using (var reader = new StreamReader(stream))
		{
			MessageBox.Show(reader.ReadToEnd());
		}
	}
