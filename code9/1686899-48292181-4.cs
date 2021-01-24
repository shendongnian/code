    public bool IsEligible()
    {
        if (Age >= 17 && Age < 21 && SwitchFinal < 20)
        {
            return true;
        }
        if (Age >= 21 && Age < 28 && SwitchFinal < 22)
        {
            return true;
        }
        if (Age >= 28 && Age <40 && SwitchFinal < 24)
        {
            return true;
        }
        if (Age >= 40 &&  SwitchFinal < 24)
        {
            return true;
        }
        return false;
    }
    void ExampleUsage()
    {
        bool ok = IsEligible();
        if (ok)
        {
            MessageBox.Show("Candidate is Eligible!");
        }
        else
        {
            MessageBox.Show("Candidate is not Eligible!");
        }
    }
    
