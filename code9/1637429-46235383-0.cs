        //global
            List<TextBox> txtServerList= new List<TextBox>();
    
    private void tabControl1_ControlAdded(object sender, ControlEventArgs e)
        {
            txtServer.Location = txtServer1.Location;
            txtServer.Width = txtServer1.Width;
            txtServer.Height = txtServer1.Height;
            txtServer.Font = txtServer.Font;
            txtServer.Name = "txtServer" + tabControl1.TabCount.ToString();
        
            txtServerList.Add(txtServer)
            .
            .
            .
        }
