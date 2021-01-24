    private void LV1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selected = (sender as ListView).SelectedItem as string;
        int index = -1;
        for (int i = 0; i < LV2.Items.Count(); i++)
        {
            if (LV2.Items[i] as string == selected){
                index = i;
                break;
            }
        }
    
        // The if becomes obsolete here, it could be replaced by 
        // if(index >= 0) 
        if (LV2.Items.ToList().Contains(selected))
        {
            LV2.SelectedIndex = index; // this doesn't work
        }
    }
