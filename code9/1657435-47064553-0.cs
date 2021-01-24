	DownloadCompleteReceiver receiver;
	var user = "httpwatch";
	var password = new Random().Next(int.MinValue, int.MaxValue).ToString();
	var uriString = "https://www.httpwatch.com/httpgallery/authentication/authenticatedimage/default.aspx?0.05205263447822417";
	using (var uri = Android.Net.Uri.Parse(uriString))
	using (var request = new DownloadManager.Request(uri))
	{
		var basicAuthentication = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{user}:{password}"));
		request.AddRequestHeader("Authorization", $"Basic {basicAuthentication}");
		request.SetNotificationVisibility(DownloadVisibility.VisibleNotifyCompleted);
		request.SetDestinationInExternalPublicDir(Android.OS.Environment.DirectoryDownloads, "someImage.gif");
		using (var downloadManager = (DownloadManager)GetSystemService(DownloadService))
		{
			var id = downloadManager.Enqueue(request);
			receiver = new DownloadCompleteReceiver(id, (sender, e) =>
			{
				Toast.MakeText(Application.Context, $"Download Complete {id}", ToastLength.Long).Show();
				if (sender is DownloadCompleteReceiver rec)
				{
					UnregisterReceiver(rec);
					rec.Dispose();
				}
			});
			RegisterReceiver(receiver, new IntentFilter(DownloadManager.ActionDownloadComplete));
			Toast.MakeText(Application.Context, $"Downloading File: {id}", ToastLength.Short).Show();
		}
	}
