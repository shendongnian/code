    XAML:
    <TextBox Name="txtNo" TextChanged="txtNo_TextChanged_1" MaxLength="1" />
    
    XAML.CS:
      private void txtNo_TextChanged_1(object sender, TextChangedEventArgs e)
            {
                TextBox txtnum = sender as TextBox;
                if (txtnum != null && txtnum.Text != null)
                {
                    try
                    {
                        var num = Convert.ToInt32(txtnum.Text);
                        txtnum.Text = num.ToString();
                    }
                    catch (Exception ex)
                    {
                        txtnum.Text = string.Empty;
                        e.Handled = true;
                    }
                }
            }
