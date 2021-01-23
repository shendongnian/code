    private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (txtPrice.Text.StartsWith("0") && !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
            return;
        }
    }
