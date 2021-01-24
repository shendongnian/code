    Button button = new Button();
	
    ...
    var subscription = button
        .ButtonClicks()
    	.Buffer(TimeSpan.FromSeconds(0.5), 100) // Perform action  after 100 clicks or after half a second, whatever comes first
    	.Select(buffer => buffer.Count)
		.Subscribe(clickCount =>
		{
			// Do something with clickCount
		})
