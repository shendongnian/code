    int i = 0;
    foreach (Panel p in panels)
    {
         var selectedRadioButton = p.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
         if (selectedRadioButton != null)
         {
               string waardenaam[i] = selectedRadioButton.Name; //an array of size 9
               string waarde[i] = selectedRadioButton.Text; //another array of size 9
         }
         i++;
    }
    WaardeObjecten obj = new WaardeObjecten(waardenaam, waarde);
