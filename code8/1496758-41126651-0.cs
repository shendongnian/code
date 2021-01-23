    public string kollaKön()
    {
        //string siffraAsString = form.textBox3.Text.Substring(8, 1);
        int siffraAsNum = GetNinthNumber(form.textBox3.Text);
        int result = (siffraAsNum % 2);
    
        if (result == 1)
        {
            return form.textBox5.Text = ("Är en Man");
        }
        else
        {
            return form.textBox5.Text = (" Är en Kvinna");
        }
    }
    
    public static int GetNinthNumber(string str)
    {
        string numberField = str.Trim();
    
        if (numberField.Length < 9)
        {
            // Handle less than 9 cases
            return 0;
        }
        else
        {
            int number;
            bool isNumber = Int32.TryParse(str[8].ToString(), out number);
    
            if (!isNumber)
            {
                throw new Exception("Value is not a number");
            }
    
            return number;
        }
    }
