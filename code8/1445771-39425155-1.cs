    StringBuilder sb = new StringBuilder();
  
     if ((Convert.ToInt32(txtQuantity.Text)) > 20000)
            {
                  sb.AppendLine("Maximum quantity is 20,000!");            
            }
      
    
    if ((Convert.ToInt32(txtQuantity.Text)) <= (Convert.ToInt32(txtCriticalLevel.Text)))
        {
           sb.AppendLine("Quantity is lower than Critical Level.");
        }
    
    ....
      MessageBox.Show(sb.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
