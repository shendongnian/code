    protected void CheckValidity(object sender, DirectEventArgs e)
    {
        //....validation check code
        if (isValid == true)
            btnCheckV.Icon = Icon.Tick;
        else
            btnCheckV.Icon = Icon.Cross;
        e.Success = true;
    }
    
