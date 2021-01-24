    foreach (Control cont in GB_Product_Entry.Controls)
    {
        if (cont is TextBox)
        {
            ((TextBox)cont).ReadOnly = true;
            ((TextBox)cont).BackColor = SystemColors.Control;
        }
        else if (cont is ComboBox)
        {
            ((ComboBox)cont).Enabled = false;
            ((ComboBox)cont).BackColor = SystemColors.Control;
        }
        else if (cont is CheckBox)
        {
            ((CheckBox)cont).Enabled = false;
          //((CheckBox)cont).BackColor = SystemColors.Control;
        }
        // Any other conditions here...
    } 
