    var mimeTypeMap = MimeTypeMap.Singleton;
    var mimeType = mimeTypeMap.GetMimeTypeFromExtension(System.IO.Path.GetExtension(filePath));
    
    var intent = new Intent();
    intent.SetAction(Intent.ActionView);
    intent.SetDataAndType(new Android.Net.Uri(filePath), mimeType);
    
    var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);
