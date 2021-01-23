    double dval;
    double abs;
    if(string.IsNullOrEmpty(txtND.Text))
    {
        txtND.Text = "Empty Input"; 
    }else if (double.TryParse(txtND.Text.Trim(), out dval))
    {
        abs = Math.Abs(dval);
        txtND.Text = abs.ToString();
    }
    else
    {
        txtND.Text = "Math Error";
    }
