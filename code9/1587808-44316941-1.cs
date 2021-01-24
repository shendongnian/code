        public void SendEmail(string subject, string body, string recipient, string mimeType, string attachmentFilePath, string activityTitle)
		{
			var emailIntent = new Intent(Intent.ActionSendMultiple);
			if (string.IsNullOrEmpty(subject)) throw new ArgumentException();
			emailIntent.PutExtra(Intent.ExtraSubject, subject);
		    if (!string.IsNullOrEmpty(recipient))
		        emailIntent.PutExtra(Intent.ExtraEmail, new[] { recipient });
			if (!string.IsNullOrEmpty(body))
				emailIntent.PutExtra(Intent.ExtraText, body);
			if (!string.IsNullOrEmpty(attachmentFilePath))
			{
				var file = new Java.IO.File(attachmentFilePath);
				file.SetReadable(true, true);
				var uri = Android.Net.Uri.FromFile(file);
				emailIntent.PutParcelableArrayListExtra(Intent.ExtraStream, new List<IParcelable>(){uri});								
			}
			emailIntent.SetType(mimeType);
			_activity.StartActivity(Intent.CreateChooser(emailIntent, activityTitle));
		}
