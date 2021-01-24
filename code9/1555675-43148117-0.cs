    private void AdjustRowDefinitions(int numberOfWeeks)
    {
        WeekRowGrid.RowDefinitions.Clear();
        for (int i = 0; i < numberOfWeeks; i++)
        {
            RowDefinition rowDef = new RowDefinition();
            rowDef.Height = new GridLength(1, GridUnitType.Star); //this sets the height of the row to *
            WeekRowGrid.RowDefinitions.Add(rowDef);
        }
    }
