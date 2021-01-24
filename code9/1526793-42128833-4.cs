    protected void ValidateDuration(object sender, ServerValidateEventArgs e)
    {
        DateTime firstDate= DateTime.Parse(txbStartDate.Text);
        DateTime secondDate = DateTime.Parse(txbEndDate.Text);
    
        if(firstDate <= secondDate)
        {
          e.IsValid = false;
        }
        else
        {
          e.IsValid = true;
        }          
    }
