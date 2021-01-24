    using System.IO;
    using System.Security.AccessControl;
    
    private void btnBrowse_Click(object sender, EventArgs e)
    {
       if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
       {
            textBox1.Text = folderBrowserDialog1.SelectedPath;
       }
    }
    
    private void btnLock_Click(object sender, EventArgs e)
    {
       try
       {
    
          string folderPath = textBox1.Text;
          string adminUserName = Environment.UserName;// getting your adminUserName
          DirectorySecurity ds = Directory.GetAccessControl(folderPath);
          FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName,  FileSystemRights.FullControl, AccessControlType.Deny)
    
          ds.AddAccessRule(fsa);
          Directory.SetAccessControl(folderPath, ds);
          MessageBox.Show("Locked");
       }
       catch (Exception ex)
       {
          MessageBox.Show(ex.Message);
       }       
    }
    
    private void btnUnLock_Click(object sender, EventArgs e)
    {
       try
       {
         string folderPath = textBox1.Text;
         string adminUserName = Environment.UserName;// getting your adminUserName
         DirectorySecurity ds = Directory.GetAccessControl(folderPath);
         FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName,  FileSystemRights.FullControl, AccessControlType.Deny)
    
         ds.RemoveAccessRule(fsa);
         Directory.SetAccessControl(folderPath, ds);
         MessageBox.Show("UnLocked");
       }
       catch (Exception ex)
       {
         MessageBox.Show(ex.Message);
       } 
    }
