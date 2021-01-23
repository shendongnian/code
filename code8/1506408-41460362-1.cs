    public void MyMethod()
    {
        Logs.Paragraph.Inlines.Add(new LineBreak());
        Logs.Paragraph.Inlines.Add(new Bold(new Run("Log Message Example")) { Foreground = Brushes.Blue });
    }
