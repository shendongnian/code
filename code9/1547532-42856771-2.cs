    private bool Checkbox_check()
    {
        // result value.
        bool result = false;
        // define a function which assigns the checkbox checked state to the result
        var checkCheckBox = new Action(() => result = checkBox1.Checked);
      
        // check if it should be invoked.      
        if (checkBox1.InvokeRequired)
            checkBox1.Invoke(checkCheckBox);
        else
            checkCheckBox();
        // return the result.
        return result;
    }
