    string input = textBox1.Text;
    double inputAsDouble;
    bool ok = double.tryParse(out inputAsDouble);
    if (!ok)
    {
        MessageBox.Show("Please enter a numeric value.");
        return;
    }
    if (inputAsDouble == roundedMoles)
    {
        MessageBox.Show("Good");
        textBox1.Clear();
