	public void Main()
	{
		var images = ImagesInFolder("c:\Users\VASIYA\Desktop\Sample Images", TaskPoolScheduler.Instance);
		var process1 = images.Subscribe(SaveBwImages);
		var process2 = images.Subscribe(SaveScaledImages);
		var process3 = images.Select(Cats).Subscribe(SaveCatsImages);
		images.Connect();
	}
