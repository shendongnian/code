        public void PropogateSecurity(string userid,string directory)
        {
            var myDirectoryInfo = new DirectoryInfo(directory);
            var myDirectorySecurity = myDirectoryInfo.GetAccessControl();
            myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(userid, FileSystemRights.Modify, InheritanceFlags.ContainerInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));
            myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(userid, FileSystemRights.Modify, InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));
            myDirectoryInfo.SetAccessControl(myDirectorySecurity);
            
        }
