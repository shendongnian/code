    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    		{
    			if((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar >= 97 && e.KeyChar <= 105))
    			{
    				e.Handled = true;
    			}
    			else
    			{
    				e.Handled = false;
    			}
    		}
