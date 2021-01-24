    private void comboSaison_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        int ind = ((ComboBox)sender).SelectedIndex;
        if(ind<0)return;// If nothing selected we must break.
        
        switch((string)comboSaison.Items[ind])
        {
            case "Ete 2017":
                comboTheme.Items.Clear();
                comboTheme.Items.AddRange(themesE17.ToArray());
                break;
            case "Hiver 2017":
                comboTheme.Items.Clear();
                comboTheme.Items.AddRange(themesH17.ToArray());
                break;
            default:
                Console.WriteLine("Nothing matches!");
                break;
        }
    }
