    RadioButton radioBtn = this.Controls.OfType<RadioButton>()
                                           .Where(x=>x.Checked).FirstOrDefault();
    if (radioBtn!=null)
    {
        switch (radioBtn.Name)
        {
            case "radioButton1":
               //Your switch structure here ...
                 
    }
