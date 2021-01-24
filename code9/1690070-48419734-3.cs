	var runnable = new MyRunnable(async () =>
	{
        // Do whatever you need, including capturing of local vars, app/activity context, etc.
		await Task.Delay(1000);
		Toast.MakeText(this, "In runnable", ToastLength.Long).Show();
		~~~
	});
	runnable.Run();
