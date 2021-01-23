        public bool Enable(int value, int max = 19, int min = 0)
        {
            if()
            return (value >= min && value <= max);
        }
    
    private void btnZurueckData_Click(object sender, RoutedEventArgs e)
    {
        dataFromGuiToObject(index);
        index--;
        if (Enable(index, zeichnungen.Count))
        {
            resetGUI();
            setDataToGui(zeichnungen, index);
            btnVorData.IsEnabled = true;
        }
        else
        {
            btnZurueckData.IsEnabled = false;
            index++;
        }
    }
    
    private void btnVorData_Click(object sender, RoutedEventArgs e)
    {
        dataFromGuiToObject(index);
        index++;
        if (Enable(index, zeichnungen.Count))
        {
            resetGUI();
            setDataToGui(zeichnungen, index);
            btnZurueckData.IsEnabled = true;
        }
        else
        {
            btnVorData.IsEnabled = false;
            btnSpeichern.IsEnabled = true;
            index--;
        }
    }
