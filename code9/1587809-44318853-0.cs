     public void OpenNatively(string filePath) {
			Android.Net.Uri uri;
			if (filePath.StartsWithHTTP()) {
				uri = Android.Net.Uri.Parse(filePath);
			}
			else {
				 uri = Android.Net.Uri.Parse("file:///" + filePath);
			}
			Intent intent = new Intent(Intent.ActionView);
			var extension = filePath.Substring(filePath.LastIndexOf(".")+1);
            if (extension == "ppt" || extension == "pptx") {
                extension = "vnd.ms-powerpoint";
            }
			var docType = "application/" + extension;
			intent.SetDataAndType(uri, docType);
			intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);
			try {
				Xamarin.Forms.Forms.Context.StartActivity(intent);
			}
			catch (Exception e) {
				Toast.MakeText(Xamarin.Forms.Forms.Context, "No Application found to view " + extension.ToUpperInvariant() + " files.", ToastLength.Short).Show();
			}
		}
