    private void comboBox_DateFormatDivider_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < _dateFormatsList.Count; i++)
        {
            _dateFormatsList[i] = _dateFormatsMasterList[i].Replace("@", comboBox_DateFormatDivider.SelectedText);
        }
    }
