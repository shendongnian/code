    private void comboSaison_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        int ind = ((ComboBox)sender).SelectedIndex;
        if(ind<0)return;// If nothing selected we must break.
        
        switch(comboSaison.Items[ind].Text)
        {
            case "Ete 2017":
                comboTheme.Items.Clear();
                comboTheme.Items.AddRange(themesE17);
                break;
            case "Hiver 2017":
                comboTheme.Items.Clear();
                comboTheme.Items.AddRange(themesH17);
                break;
            default:
                Console.WriteLine("Nothing matches!");
                break;
        }
    }
