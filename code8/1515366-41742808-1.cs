    ...
    if (radioButton1.Checked)
    {
        //label2.Text = "100";
        // by Convert.ToInt32()
        ChosenMovie = ChosenMovie + Convert.ToInt32(label2.Text);
        // or, by int.TryParse()
        ChosenMovie = ChosenMovie + int.TryParse(label2.Text);
    }
