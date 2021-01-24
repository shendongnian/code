    decimal grade;
    if(!decimal.TryParse(txtBoxGrade.Text, out grade))
    {
         MessageBox.Show(string.Format("Unable to parse '{0}'.", txtBoxGrade.Text));
         return;
    }
    
