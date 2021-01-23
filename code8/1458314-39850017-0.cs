	protected override void OnStartup(StartupEventArgs e)
	{
		var fileName = Environment.CurrentDirectory() + @"\Resources\AdditionalStyles.xaml";
		
		// Check if the AdditionalStyles.xaml file exists
		if (File.Exists(fileName)
		{
			try
			{
                // try and load the file as a dictionary and add it the dictionaries
				var additionalStylesDict = (ResourceDictionary)XamlReader.Load(fs);
				Resources.MergedDictionaries.Add(additionalStylesDict);
			}
			catch (Exception ex)
			{
				// something went wrong loading the resource file
			}
		}
		// any other stuff on startup
		// call the base method
		base.OnStartup(e);
	}
