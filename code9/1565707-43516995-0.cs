    if (!rbmale.Checked & !rbfemale.Checked & !rbothers.Checked)
    {
    }
    if (new[] {rbmale.Checked,rbfemale.Checked,rbothers.Checked}.All(x => !x))
    {
    }
    if (!rbmale.Checked || !rbfemale.Checked || !rbothers.Checked)
    {      
    
    }
    else
    {
        MessageBox.Show("Please select gender ", "Error");
        return;
    }
