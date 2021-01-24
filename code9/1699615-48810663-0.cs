       void length_textbox_numeric_check(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsControl(e.KeyChar)) )
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
