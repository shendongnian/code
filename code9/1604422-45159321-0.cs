        void CopyColumn()
        {
            if (this.dataGridView1.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    Clipboard.SetDataObject(this.dataGridView1.GetClipboardContent());
                    string sText = Clipboard.GetText();
                    string sColumn = FormatColumn(sText);
                    Clipboard.SetData(DataFormats.Rtf, sColumn); // this will set the proper format of the Uncertainty column in clipboard memory 
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    MessageBox.Show("The Clipboard could not be accessed. Please try again.");
                }
            }
        }
        
        string FormatColumn(string sValues)
        {
            int nlines = NumLines(sValues);
            string[] values = Values(sValues);
            
            string sStart = @"{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang3081{\fonttbl{\f0\froman\fprq2\fcharset0 Times New Roman;}}
