    float value;
    if(!float.TryParse(textBox.Text, out value,
            System.Globalization.CultureInfo.CurrentCulture))
    {
        MessageBox.Show("Wrong input!");
    }
