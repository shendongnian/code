    private async void OnSourceChanged(Uri source)
    {
    	var file = await StorageFile.GetFileFromApplicationUriAsync(source);
    
    	string xaml;
    
    	using (var stream = await file.OpenReadAsync())
    	using (var reader = new StreamReader(stream.AsStream()))
    	{
    		xaml = reader.ReadToEnd();
    	}
    
    	this.Content = XamlReader.Load(xaml);
    }
