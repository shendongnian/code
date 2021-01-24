    private void MeretTB_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.Handled = true;
            myButton.PerformClick();
        }
    }
