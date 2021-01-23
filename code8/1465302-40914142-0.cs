      if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
            {
                int mycode = 0;
                Android.Support.V4.App.ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.Camera }, mycode);
            }    
     public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {            
            ZXing.Net.Mobile.Forms.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
