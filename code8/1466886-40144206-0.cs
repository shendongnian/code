    int i1, i2, i3;
    if (!int.TryParse(txtNum1.Text, out i1) || i1 < 0) { MessageBox.Show("Please enter a positive first number" ); return; }
    if (!int.TryParse(txtNum2.Text, out i2) || i2 < 0) { MessageBox.Show("Please enter a positive second number"); return; }
    if (!int.TryParse(txtNum3.Text, out i3) || i3 < 0) { MessageBox.Show("Please enter a positive third number" ); return; }
    int sum = i1 + i2 + i3;
    txtResult.Text = sum.ToString();
