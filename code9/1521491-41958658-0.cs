    public string Power
    {
       get { return txtPower.Text; }
       set 
       { 
           if(ValidatePower(value))
           {
               txtPower.Text = value;
           }
           else
           {
               // throw ??
           }
        }
    }
