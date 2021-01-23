    public struct Server
    {
        public string ServerName { get; set; }
    }
    comboBoxServers.DisplayMember = "ServerName";
    comboBoxServers.DataSource = MyServers;
