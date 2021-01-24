     private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '.' || e.KeyChar == Convert.ToChar(Keys.Back))
                {
                    if (e.KeyChar == '.' && textIIC.Text.Contains('.'))
                    {
                        e.Handled = true;
                    }
                    return;
                }
                e.KeyChar = Char.ToUpper(e.KeyChar);
                decimal isNumber = 0;
                e.Handled = !decimal.TryParse(e.KeyChar.ToString(), out isNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
