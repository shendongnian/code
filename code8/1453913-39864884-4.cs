        //Select the chosen TabItem 
        public void RskPrcssPrcdrs_Click(object sender, ExecutedRoutedEventArgs e)
        {
            RskManWndw rskManWndw = new RskManWndw(this);      //Instantiate a new rskManWndw window
            TabControl tabControlCollection = new TabControl();
            TabItem tabItemCollection = new TabItem();
            string slctdTabItem = (string)e.Parameter;
            bool slctdTabItemFnd = false;
            string msgBoxMsg = "";
            //Open the rskAraManWndw window
            rskManWndw.Show();
            foreach (TabItem tabItem in rskManWndw.RskManPrcssTbCtl.Items)
            {
                if (tabItem.Name == slctdTabItem)
                {
                    tabItem.IsSelected = true;                          //Select the chosen TabItem.
                    slctdTabItemFnd = true;                             //Flag that the TabItem was found.
                    break;
                }
            }
            if (slctdTabItemFnd == false)                               //Was the TabItem found?
            {
                msgBoxMsg = "A TabItem matching the" + slctdTabItem + "Command Parameter was not found.  "
                          + "Please inform the system administrator.";
                MessageBox.Show($" {msgBoxMsg}", "RMS Processing Error Alert");
                rskManWndw.Close();
            }
            else
            {
                Hide();                                                     //Hide the Risk_Management_System.MainWindow
            }
        }
