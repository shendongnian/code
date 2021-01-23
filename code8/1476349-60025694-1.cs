           // Adds an ACL entry on the specified directory for the specified account.
        public static void AddDirectorySecurity(string FileName, string Account, FileSystemRights Rights, AccessControlType ControlType)
        {
            // Create a new DirectoryInfo object.
            DirectoryInfo dInfo = new DirectoryInfo(FileName);
            // Get a DirectorySecurity object that represents the 
            // current security settings.
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            // Add the FileSystemAccessRule to the security settings. 
            dSecurity.AddAccessRule(new FileSystemAccessRule(Account,
                                                            Rights,
                                                            ControlType));
            // Set the new access settings.
            dInfo.SetAccessControl(dSecurity);
        }
        // Removes an ACL entry on the specified directory for the specified account.
        public static void RemoveDirectorySecurity(string FileName, string Account, FileSystemRights Rights, AccessControlType ControlType)
        {
            // Create a new DirectoryInfo object.
            DirectoryInfo dInfo = new DirectoryInfo(FileName);
            // Get a DirectorySecurity object that represents the 
            // current security settings.
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            // Add the FileSystemAccessRule to the security settings. 
            dSecurity.RemoveAccessRule(new FileSystemAccessRule(Account,
                                                            Rights,
                                                            ControlType));
            // Set the new access settings.
            dInfo.SetAccessControl(dSecurity);
        }
        // Adds an ACL entry on the specified file for the specified account.
        public static void AddFileSecurity(string fileName, string account,
            FileSystemRights rights, AccessControlType controlType)
        {
            // Create a new FileInfo object.
            FileInfo fInfo = new FileInfo(fileName);
            // Get a FileSecurity object that represents the 
            // current security settings.
            FileSecurity fSecurity = fInfo.GetAccessControl();
            // Add the FileSystemAccessRule to the security settings.
            fSecurity.AddAccessRule(new FileSystemAccessRule(account,
                rights, controlType));
            // Set the new access settings.
            fInfo.SetAccessControl(fSecurity);
        }
        // Removes an ACL entry on the specified file for the specified account.
        public static void RemoveFileSecurity(string fileName, string account,
            FileSystemRights rights, AccessControlType controlType)
        {
            // Create a new FileInfo object.
            FileInfo fInfo = new FileInfo(fileName);
            // Get a FileSecurity object that represents the 
            // current security settings.
            FileSecurity fSecurity = fInfo.GetAccessControl();
            // Remove the FileSystemAccessRule from the security settings.
            fSecurity.RemoveAccessRule(new FileSystemAccessRule(account,
                rights, controlType));
            // Set the new access settings.
            fInfo.SetAccessControl(fSecurity);
        }
        //example for open onClick folderdialog and get owner by NTACCOUNT of folder from acl
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");
            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                // Application now has read/write access to all contents in the picked folder
                // (including other sub-folder contents)
                Windows.Storage.AccessCache.StorageApplicationPermissions.
                FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                // Create a new FileInfo object.
                FileInfo fInfo = new FileInfo(folder.ToString());
                // Get a FileSecurity object that represents the 
                // current security settings.
                FileSecurity fSecurity = fInfo.GetAccessControl();
                IdentityReference identityReference = fSecurity.GetOwner(typeof(SecurityIdentifier));
                NTAccount ntAccount = identityReference.Translate(typeof(NTAccount)) as NTAccount;
                var fileOwner = ntAccount.Value;
                //do something with file Owner
                //this.tb1.Text = "folder: " + folder.Name + " in Pfad: " + folder.Path + "owned by: " + fileOwner;
            }
            else
            {
                //error Handler
            }
        }
