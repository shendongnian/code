    foreach (var control in this.Controls)
    {
        if (control is CheckBox)
        {
            if (ffcheck.Checked)
            {
                int TextboxValue = int.Parse(InitAmo.Text);
                TextboxValue = TextboxValue + 50;
                string NewValue = TextboxValue.ToString();
                InitAmo.Text = "P" + NewValue + ".00";
            }
        }
    }
