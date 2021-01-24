    public string getValue(string controlName, TabPage selectedTab)
    {
      if (selectedTab.Controls.ContainsKey(controlName)){
        TextBox selectedtb = (TextBox)selectedTab.Controls[controlName];
        return selectedtb.Text;
        }
       else
         return null;
    }
