    private string FolderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // location of document folder
     private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage tpp = tabControl1.SelectedTab;
            this.FileOnly = tpp.Text + ".txt"; // I used tab names without extension, that's why adding it back
            String str = tpp.Text;
            string CorrFolderPath = FolderPath.Replace(@"\", @"\\");
            string FolderPathcomplete = CorrFolderPath + "\\My_Note\\"; // this is the location of saving files; the folder contents appear as list box entries in the program
            string filename = FolderPathcomplete + FileOnly;
            if (str.Contains("New Document"))// the new tabs which are not yest saved has the name New Document 1, 2 etc.
            {
                return;
            }
            else
            {
                if (File.Exists(filename))
                {
                    return;
                }
                else
                {
                    MessageBox.Show("File does not exist! Closing the tab.");
                    var tabPage = tabControl1.TabPages[str];
                    tabControl1.TabPages.RemoveByKey(str);
                }
            }
        }
    private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("New Document" + count); //creates a new tab page
            tp.Name = "New Document" + count;
            RichTextBox rtb = new RichTextBox(); //creates a new richtext box object
            
            tp.Controls.Add(rtb); // adds rich text box to the tab page
            tabControl1.TabPages.Add(tp); //adds the tab pages to tab control
            tabControl1.SelectedTab = tp;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged; // it will check whether tab file exists or not
            this.FileName = string.Empty;
            count++;
            
        }
