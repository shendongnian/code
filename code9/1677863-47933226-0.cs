	IObservable<Unit> fileChanges =
		Observable
			.Using(() =>
			{
				var fsw = new FileSystemWatcher();
				fsw.Path = path;
				fsw.EnableRaisingEvents = true;
				return fsw;
			}, fsw =>
				Observable
					.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
						h => fsw.Changed += h,
						h => fsw.Changed -= h))
			.Select(ep => Unit.Default);
	IObservable<Unit> periodically =
		Observable
			.Interval(TimeSpan.FromSeconds(30.0))
			.Select(x => Unit.Default);
	IObservable<string> clearMissedFiles =
		fileChanges
			.Merge(periodically)
			.SelectMany(u => Directory.GetFiles(ConfigurationHelper.applicationRootDirectory, "*.txt", SearchOption.TopDirectoryOnly))
			.Where(f => !FileHelper.CheckIfFileInUse(filesInUseCollection, f))
			.SelectMany(f => Observable.Start(() => FileHelper.SendFileToApi(userid, f)), (f, s) => new { file = f, success = s })
			.Where(x => x.success)
			.Select(x => x.file);
			
	IDisposable subscription =
		clearMissedFiles
			.Subscribe(f => File.Delete(f));
