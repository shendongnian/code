    private void Cancel_btn_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
    private void Form_closing(object sender, FormClosingEventArgs e)
    {
        DialogResult dialog = MessageBox.Show("Do you really want to close the program?", "program close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (dialog == DialogResult.Yes)
        {
            e.Cancel = false;
        }
        else if (dialog == DialogResult.No)
        {
            e.Cancel = true;
        }
    }
