    string values = richTextBox1.Text;
    string[] numberCount = values.Split(delimiterChars);
    double totalValue = 0;
    foreach (string s in numberCount)
    {
       var doubleValue = Convert.ToDouble(s); 
       totalValue += doubleValue;
       MessageBox.Show(doubleValue - doubleValue);
    }
