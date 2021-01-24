    var panels = Controls.OfType<Panel>().ToList();
    foreach (Panel p in panels)
    {
         var selectedRadioButton = p.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
         if (selectedRadioButton != null)
         {
              MessageBox.Show($"{p.Name}.{selectedRadioButton.Text}");
         }
    }
