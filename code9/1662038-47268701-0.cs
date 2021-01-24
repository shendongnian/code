                var myDirectoryInfo = new DirectoryInfo(folderpath);
                var myDirectorySecurity = myDirectoryInfo.GetAccessControl();
                myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(Model.UserId, FileSystemRights.Modify, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
                myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(Model.UserId, FileSystemRights.Modify, InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                myDirectoryInfo.SetAccessControl(myDirectorySecurity);
