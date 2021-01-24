    try
    {  
      int n;
        bool isNumeric = int.TryParse(txt_pay2.Text, out n);
        if(isNumeric)
        {
         if (!string.IsNullOrEmpty(txt_pay2.Text))
                    {
                       txt_dues2.Text = (Convert.ToInt32(pay_dues.Text) - Convert.ToInt32(txt_pay2.Text)).ToString();
        
                    }
                    else if (String.IsNullOrEmpty(txt_pay2.Text))
                    {
                        MessageBox.Show("Enter A Amount Please !!");
                    }
        }
        else
        { 
        MessageBox.Show("Enter A  Please !!");
        }
    }
     catch (Exception Ex)
            {
    
                MessageBox.Show(Ex.Message);
            }
