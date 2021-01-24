    using Uri = Android.Net.Uri;
    Intent intent = new Intent(Intent.ActionView);
    intent.SetDataAndType(Uri.Parse("file:///" + PathToFile(filename)), "application/pdf");
    intent.SetFlags(ActivityFlags.ClearTop);
    StartActivity(intent);
    return null;
