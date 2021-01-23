    string[] commonJurisdiction = s3.Split(',').Select(s => s.Trim()).ToArray();
    // make sure the spaces are filtered out by trimming
    string result;
    int index = commonJurisdiction.IndexOf(txtResidentState.Text);
    if(index >= 0)
    {
        commonJurisdiction.Remove(index);
        result = string.Join(", ", commonJurisdiction);
        txtJurisdiction.Text = Result;
    }
