    public static IConnectableObservable<System.Drawing.Bitmap> ImagesInFolder(string path, IScheduler scheduler)
    {
        return
			Directory
				.GetFiles(path, "*.bmp")
            	.ToObservable(scheduler)
            	.SelectMany(x =>
					Observable
						.Using(
							() => new System.Drawing.Bitmap(x),
							bm => Observable.Return(bm)))
                .Publish();
    }
