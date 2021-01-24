    protected void lvSurvey_ItemCommand(object source, ListViewCommandEventArgs e)
                {
                    if(e.CommandName == "DeleteObject")
                    {
                        string[] param = e.CommandArgument.ToString().Split('|');
                        hfInstallID.Value = param[0].ToString();
        
                        DELETEINSTALL(int.Parse(hfInstallID.Value), clsCommon.gConstDTOMode_Delete, clsCommon.gConstActive_Status);
                        GetAllOrderInstall();
        
                        TabName.Value = "installation";
                        litMsg.Text = "Record deleted successfully";
                    }
        
                    GetAllOrderInstall();
               }
