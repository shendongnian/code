     protected void doSomething_Checked(object sender, CommandEventArgs e)
       {
                CheckBox ctrl = (CheckBox)sender;
                RepeaterItem rpItem = ctrl.NamingContainer as RepeaterItem;
                if (rpItem != null)
                {
                    CheckBox chkBox = (CheckBox)rpItem.FindControl("chkBoxID");
                    chkBox.DoSomethingHere...
                }
       }
