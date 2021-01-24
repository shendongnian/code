    double doubleValue;
    string Value = Convert.ToString(GirdView.Rows[j].Cells[i].Text);
    bool isDouble = Double.TryParse(Value, out doubleValue);
    if(isDouble) 
    {
          // double here
    }
    else
    {
         //Other format here
    }
