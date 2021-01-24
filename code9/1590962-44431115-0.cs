    private async void btnGo_Click(object sender, EventArgs e)
    {
        if (checkM.Checked == true && checkI.Checked == false && checkA.Checked == false && checkQ.Checked == false)
        {
            await mParsing(textFiles);
            DialogResult dialogResult = MessageBox.Show("View Summary?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string summary = filepath;
                Process.Start("notepad.exe", summary);
            } 
        }
    }
