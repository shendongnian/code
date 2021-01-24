    private void Cancel_btn_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
    private void Form_closing(object sender, FormClosingEventArgs e)
    {
        DialogResult dialog = MessageBox.Show("Do you really want to close the program?", "program close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (dialog == DialogResult.No)
            e.Cancel = true;
        // TODO: Add 'else' if you want to call a cleanup
        // method or do something before the application closes.
    }
