     private int MsgTabPage = 0; // the tab page that the msgbox should be displayed
     public bool IsOn
     {
         get
         {
             return _isOn;
         }
         set
         {
             bool someCondition = false;
             // a test is done
             if (value != _isOn && someCondition)
             {
                 _isOn = value;
             }
             else
             {
                 if(tabControl1.SelectedIndex == MsgTabPage)
                 System.Windows.Forms.MessageBox.Show("Condition not OK");
             }
         }
     }
