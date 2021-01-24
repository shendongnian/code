    DataLakeStoreFileSystemManagementClient _adlsFileSystemClient = new DataLakeStoreFileSystemManagementClient();
    
    public static void Move(string src_path, string dest_path)
                    {
                        _adlsFileSystemClient.FileSystem.Rename(_adlsAccountName, src_path, dest_path);
                    }
