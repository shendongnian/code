    List<string> arrTeamMembers = new List<string>(); 
    foreach (ManagementObject queryObj in searcher8.Get())
    {
        arrTeamMembers.Add(queryObj["Description"].ToString());
    }
    richTextBox1.Text = string.Join(",", arrTeamMembers);
