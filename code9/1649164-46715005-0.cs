    private void txtNo_KeyPress (object sender, KeyPressEventArgs e)
    {
        topic = cmbTopic.Text;
        //**This is to get the cell value of the DataTable**
        int total = Int32.Parse (dTable.Rows [0] [0].ToString ());
        //**Int32.Parse(txtNo.Text) >= total, convert the txtNo.Text to integer and compare it to total (total number of rows), ideally**
        if (!char.IsControl (e.KeyChar) && !char.IsDigit (e.KeyChar) || char.IsDigit(e.KeyChar) && txtNo.Text.Length > 0 && Int32.Parse (txtNo.Text + e.KeyChar) > total)
        {
            System.Media.SystemSounds.Beep.Play (); //**Plays a beep sound to alert an error**
            e.Handled = true; //**Prevent the character from being entered**
        }
    }
