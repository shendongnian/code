    List<string> missingData = new List<string>();
    if (cmbPolType.SelectedItem == null)
        missingData.Add("Policy Type");
    if (cmbPolNum.SelectedItem == null)
        missingData.Add("Policy Number");
    if (cmbLossType.SelectedItem == null)
        missingData.Add("Loss Type");
    if (cmbLossDesc.SelectedItem == null)
        missingData.Add("Loss Description");
    if (cmbTPReg.SelectedItem == null)
        missingData.Add("TP Reg");
    if (cmbInsdFault.SelectedItem == null)
        missingData.Add("Insd at Fault");
        
    if(missingData.Count > 0)
       MessageBox.Show("You have not selected options for the following: " + 
           Environment.NewLine + string.Join(Environment.NewLine, missingData.ToArray()));
