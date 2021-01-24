    public short client;
    public void ClientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        client = (short)ClientList.SelectedValue;
        foreach (var orgComm in orgComms)
        {
            if(orgComm.OrgId == client)
            {
               CommList.ItemsSource = orgComm.CommunicationTemplateConfigs;
               CommList.SelectedIndex = 0;
            }
        }
    }
