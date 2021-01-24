    if (octalRadioButton.Checked)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) ||  char.IsWhiteSpace(e.KeyChar))
        { 
            e.Handled = true;
        }
        e.Handled = false; <----------
    }
