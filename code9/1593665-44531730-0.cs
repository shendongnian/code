    private void WriteDates(int NumberOfDates)
    {
        LblDate.Text = string.Join(string.Empty, 
            Enumerable.Range(0, NumberOfDates)
                .Select(n => $"{RandomDay().ToShortDateString()}<br />"));
    }
