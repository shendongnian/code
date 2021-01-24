    tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);
        void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
                     
            tabControl1.TabPages[tabControl1.SelectedIndex].Controls.Add(textBox);
        }
