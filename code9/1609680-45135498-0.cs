        var unixFileInfo = new Mono.Unix.UnixFileInfo("test.txt");
        // set file permission to 644
        unixFileInfo.FileAccessPermissions =
            FileAccessPermissions.UserRead | FileAccessPermissions.UserWrite
            | FileAccessPermissions.GroupRead
            | FileAccessPermissions.OtherRead;
