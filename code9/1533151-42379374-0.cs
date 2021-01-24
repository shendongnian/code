	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		using (var newsForm = new NewsForm())
		{
			DialogResult dr = newsForm.ShowDialog();
			switch (dr)
			{
				case DialogResult.Yes:
					using (var game = new Game1())
					{
						game.Run();
						newsForm.Close();
						newsForm.Dispose(); // since you open the form with ShowDialog(), you must dispose of it manually.
					}
					break;
				case DialogResult.No:
					using (var editor = new EditorForm())
					{
						Application.Run(editor);
						newsForm.Close();
						newsForm.Dispose(); // since you open the form with ShowDialog(), you must dispose of it manually.
					}
					break;
			}
		}
	}
