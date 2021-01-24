    private const string password = "xxxyyyzzz";
    private void BtnPW_Click(object sender, EventArgs e)
    {
         if(Verify())
             this.DialogResult = DialogResult.Yes;
         else
         {
             MessageBox.Show("Error: Incorrect password");
             this.DialogResult = DialogResult.No;
         }
    }
