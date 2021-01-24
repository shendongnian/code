	public async Task ReactiveTest()
	{
		IObservable<string> combined =
			Observable.Defer(() =>
			{
				var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "win.ini");
				return
					Observable.Using(
						() => File.OpenRead(filePath),
						readFile =>
							Observable.Using(
								() => new StreamReader(readFile),
								reader =>
									Observable
										.Defer(() => Observable.FromAsync(() => reader.ReadLineAsync()))
										.Repeat()
										.TakeWhile(x => x != null)));
			});
	
		int count = await combined.Count();
	}
