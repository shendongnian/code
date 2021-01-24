    tabControl1.Selecting += new tabControlCancelEventHandler(tabControl1_Selecting);
        void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
                     
            tabControl1.TabPages[tabControl1.SelectedIndex].Controls.Add(textBox);
        }
