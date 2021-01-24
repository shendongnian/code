    string[] PermissionsArray = null;
      
    protected override void OnCreate(Bundle bundle)
            {
                    TabLayoutResource = Resource.Layout.Tabbar;
                    ToolbarResource = Resource.Layout.Toolbar;
    
                    base.OnCreate(bundle);
    
                    global::Xamarin.Forms.Forms.Init(this, bundle);
                  
                    LoadApplication(new App());
    
                    Initializer.Initialize();
                    updateNonGrantedPermissions();
    
                    try
                    {
                        if (PermissionsArray != null && PermissionsArray.Length > 0)
                        {
                            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
                            {
                                ActivityCompat.RequestPermissions(this, PermissionsArray, 0);
                            }
                        }
                    }
                    catch(Exception oExp)
                    {
    
                    }
    }
    
     private void updateNonGrantedPermissions()
            {
                try
                {
                    List<string> PermissionList = new List<string>();
                    PermissionList.Add(Manifest.Permission.MediaContentControl);
                    if (ContextCompat.CheckSelfPermission(Forms.Context, Manifest.Permission.RecordAudio) != (int)Android.Content.PM.Permission.Granted)
                    {
                        PermissionList.Add(Manifest.Permission.RecordAudio);
                    }
                    if (ContextCompat.CheckSelfPermission(Forms.Context, Manifest.Permission.WriteExternalStorage) != (int)Android.Content.PM.Permission.Granted)
                    {
                        PermissionList.Add(Manifest.Permission.WriteExternalStorage);
                    }
                    if (ContextCompat.CheckSelfPermission(Forms.Context, Manifest.Permission.ReadPhoneState) != (int)Android.Content.PM.Permission.Granted)
                    {
                        PermissionList.Add(Manifest.Permission.ReadPhoneState);
                    }
                    PermissionsArray = new string[PermissionList.Count];
                    for (int index = 0; index < PermissionList.Count; index++)
                    {
                        PermissionsArray.SetValue(PermissionList[index], index);
                    }
                }
                catch(Exception oExp)
                {
                    
                }
            }
