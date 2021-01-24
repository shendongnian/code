    double a=0;
    double b=0;
    double c=0;
    
    double.TryParse(textBox1.Text.Trim(), out a);
    double.TryParse(textBox2.Text.Trim(), out b);
    double.TryParse(textBox3.Text.Trim(), out c);
    double totalVal = a+b+c;
    
