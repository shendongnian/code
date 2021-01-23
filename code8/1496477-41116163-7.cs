    public void FilterSelectionChanged(object sender, EventArgs e)
    {
        var radioButton = (RadioButton)sender;
        if(radioButton.Name == "filter1")
        {
            siteStatusControl.UpdateFilter(Filter.Filter1);
        } else if (radioButton.Name == "filter2")
        {
            siteStatusController.UpdateFilter(Filter.Filter2); 
        }else if (radioButton.Name == "filter3")
        {
            siteStatusControl.UpdateFilter(Filter.Filter3); 
        }
    }
