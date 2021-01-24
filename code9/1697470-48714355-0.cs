	if (doneIndexing.HasValue && doneIndexing == true)
	{
		var indexStatusView = FindViewById<TextView>(Resource.Id.indexStatusView);
		var indexProgress = FindViewById<ProgressBar>(Resource.Id.indexProgress);
		Log.Debug(TAG, "Done indexing, updating UI");
		RunOnUiThread(() =>
		{
			indexStatusView.Text = GetString(Resource.String.done_indexing);
			indexProgress.Visibility = ViewStates.Gone;
		});
		checkTimer.Enabled = false;
	}
