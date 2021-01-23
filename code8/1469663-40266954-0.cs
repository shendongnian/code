                var dir = "test_folder";
    			var fileName = Path.Combine(dir, "test.xml");
    
    			System.Security.Principal.WindowsIdentity wi = System.Security.Principal.WindowsIdentity.GetCurrent();
    			string user = wi.Name;
    
    			MessageBox.Show(user);
    
    			DirectorySecurity dsec = Directory.GetAccessControl(dir);
    			dsec.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.Modify, AccessControlType.Allow));
    			try
    			{
    				Directory.SetAccessControl(dir, dsec);
    				File.WriteAllText(fileName, "test");
    			}
    			catch (UnauthorizedAccessException uae)
    			{
    				MessageBox.Show(uae.Message);
    			}
    			catch (SecurityException se)
    			{
    				MessageBox.Show(se.Message);
    			}
