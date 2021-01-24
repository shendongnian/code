    private void DisplayText(string rawData)
    {
        textArduinoData.Text = rawData;
        string[] sortedData = rawData.Split(';');
        int index;
        for (int i = 0; i < sortedData.Length; i++)
        {
            if ((index = listPortData.Items.IndexOf(sortedData[i])) == -1)
            {
                listPortData.Items.Add(sortedData[i]);
            }
        }
    }
