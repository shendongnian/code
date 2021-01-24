      private bool IsThereAnAppToTakePictures()
         {
             Intent intent = new Intent(MediaStore.ActionImageCapture);
             IList<ResolveInfo> availableActivities =
                 PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
             return availableActivities != null && availableActivities.Count > 0;
         }
