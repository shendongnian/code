    int i = 0;
    string waardenaam[9];
    string waarde[9];
    foreach (Panel p in panels)
    {
         var selectedRadioButton = p.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
         
         if (selectedRadioButton != null)
         {
               waardenaam[i] = selectedRadioButton.Name;
               waarde[i] = selectedRadioButton.Text;
         }
         i++;
    }
    WaardeObjecten obj = new WaardeObjecten(waardenaam, waarde);
