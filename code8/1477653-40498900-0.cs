    public override void OnApplyTemplate()
    {
        if (!this.Columns.Any(c => c.Header.ToString() == "Column1"))
        {
            this.Columns.Insert(0,
                                new DataGridTextColumn
                                {
                                    Width = this.Column1Width,
                                    Header = "Column1"
                                });
        }
        if (!this.Columns.Any(c => c.Header.ToString() == "Column2"))
        {
            this.Columns.Insert(1,
                                new DataGridTextColumn
                                {
                                    Width = this.Column2Width,
                                    Header = "Column2"
                                });
        }
        base.OnApplyTemplate();
    }
