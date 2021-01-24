    ObjectQuery query8 = new ObjectQuery("SELECT * FROM Win32_SystemDriver");
    using (ManagementObjectSearcher searcher8 = new ManagementObjectSearcher(scope, query8))
    {
       List<string> arrTeamMembers = new List<string>(); 
      foreach (ManagementObject queryObj in searcher8.Get())
      {
          arrTeamMembers.Add(queryObj["Description"].ToString());
      }
      richTextBox1.Text = string.Join(Environment.NewLine, arrTeamMembers);
    }
