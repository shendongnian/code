    int i = 0;
    foreach (Panel p in panels)
    {
         var selectedRadioButton = p.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
         string waardenaam[9];
         string waarde[9];
         if (selectedRadioButton != null)
         {
               waardenaam[i] = selectedRadioButton.Name; //an array of size 9
               waarde[i] = selectedRadioButton.Text; //another array of size 9
         }
         i++;
    }
    WaardeObjecten obj = new WaardeObjecten(waardenaam, waarde);
