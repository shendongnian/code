    private decimal findTotal( )
    {
        decimal TotalDec = 0;
        //add size cost to total 
       if (sizeDDB .SelectedIndex == 0)
            TotalDec += 12;
        if (sizeDDB.SelectedIndex==1)  
            TotalDec += 14;
        if (sizeDDB.SelectedIndex == 2)
            TotalDec += 16;
        //add chrust cost
        if (crustDDB.SelectedIndex == 2)
            TotalDec += 2;
        // add topping cost
        if (sausageCB.Checked)
            TotalDec += 2;
        if (pepperoniCB.Checked)
            TotalDec += (decimal)1.5; //there is no automatic casting from double to decimal, so you have to do it manually like this
        return TotalDec;
    }
