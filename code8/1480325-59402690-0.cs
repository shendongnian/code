 cs
var pathToGrantRights = fs.Path.Combine(Folder, "App_Data");
fs.Directory.CreateDirectory(pathToGrantRights);
var acl = fs.Directory.GetAccessControl(pathToGrantRights);
string acc = $"IIS APPPOOL\\{webapp.ApplicationPoolName}";
acl.AddAccessRule(new FileSystemAccessRule(acc, FileSystemRights.Modify, AccessControlType.Allow));
acl.AddAccessRule(new FileSystemAccessRule(acc, FileSystemRights.Modify, InheritanceFlags.ContainerInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));
acl.AddAccessRule(new FileSystemAccessRule(acc, FileSystemRights.Modify, InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));
fs.Directory.SetAccessControl(pathToGrantRights, acl);
When you add the inheritance for folders and files in addition to the object itself, it starts working properly.
