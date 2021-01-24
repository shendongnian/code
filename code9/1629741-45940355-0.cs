    private void BtnRemoveTextbox2_Click(object sender, EventArgs e)
    {
        MetroFramework.Controls.MetroTextBox tbx = this.Controls.Find("Textbox2", true).FirstOrDefault() as MetroFramework.Controls.MetroTextBox;
        if (tbx != null)
        {
            this.Controls.Remove(tbx);
        }
    }
