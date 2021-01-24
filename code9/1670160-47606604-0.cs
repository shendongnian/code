        age = (int)NumericUpDownAge.Value;
        if (Movie3RadioButton.Checked && age < 17)
        {
            ageVerificationLabel.Text = String.Format("Access denied - you are too young");
        }
        else if (Movie4RadioButton.Checked || Movie5RadioButton.Checked || Movies6RadioButton.Checked && age < 13)
        {
            ageVerificationLabel.Text = String.Format("Access deniad - you are too young");
        }
        else
        {
            ageVerificationLabel.Text = String.Format("Enjoy your Movie");
        }
