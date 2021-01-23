    private Dictionary<string, List<string>> _data = new Dictionary<string, List<string>>
    {
        { "TO", new List<string> { "TO AS SUP", "TO AS PIP" }},
        { "DCC", new List<string> { "DCC MONO LC", "DCC MONO RE" }},
        { "MAT", new List<string> { "MAT NIS", "MAT DATA" }},
    };
    comboBoxLocation.DataSource = data.Keys.ToList();
    private void txtlocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        var comboBoxLocations = (ComboBox)sender;
        comboBoxSteps.DataSource = _data[comboBoxLocations.SelectedValue];
    }
