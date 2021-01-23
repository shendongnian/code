	DependencyService.Get<IGlobalTouch>().Subscribe((sender, e) =>
	{
		var point = (e as TouchEventArgs<Point>).EventData;
		System.Diagnostics.Debug.WriteLine($"{point.X}:{point.Y}");
	});
