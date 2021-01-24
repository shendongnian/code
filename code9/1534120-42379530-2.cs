    try 
    {
        weekhours = Convert.ToDouble(txtWeekHours.Text);
    }
    catch(FormatException)
    {
        MessageBox.Show("Invalid input into the \"Week hours\" box. Enter a decimal number.");
    }
