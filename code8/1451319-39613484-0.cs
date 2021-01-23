    void    Config_Clicked()
    {
       ConfigDlg dlg = new ConfigDlg();
       if(dlg.ShowDialog() == OK)
       {
           this.myListView1.Items.Add(dlg.userInput[0]);
       }
    }
