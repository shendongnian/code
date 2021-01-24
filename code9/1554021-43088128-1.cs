        private void ClickMyRadioButton1()
        {
            if (radioOff1.Checked)
            {
                radioOff1.PerformClick();
                ListViewItem lvi = new ListViewItem("All USB's are off");
                listView1.Items.Add(lvi);
            }
        }
    
        int counter = 0;
    
        private void tmrUSB_Tick(object sender, EventArgs e)
        {
            if (counter != 50) 
            {
               counter++;
               return;
            }
            else
            { 
                counter = 0;
            }
            //Everything in here is repeated constantly
            USBObject.receiveViaUSB();
            listView1.EnsureVisible(listView1.Items.Count - 1);
            if ( tabPage1 == tabControl1.SelectedTab)
            {
                this.radioOff2.Checked = true;
    
                if (radioOff1.Checked == true)
                {
                    USBObject.fromHostToDeviceBuffer[1] = USB_OFF;
                    ClickMyRadioButton1(); //This is what I only want to send one tine to my ListBox
                }
          }
