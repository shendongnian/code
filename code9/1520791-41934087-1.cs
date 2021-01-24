    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        DialogResult dg = MessageBox.Show("Do you want to save changes?", "Closing", MessageBoxButtons.YesNoCancel);
        if (dg == DialogResult.Yes)
        {
            if (SaveStuff() == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        else if (dg == DialogResult.Cancel)
        {
            e.Cancel = true;
        }
    }
