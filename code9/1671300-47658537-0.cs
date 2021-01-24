    public MonthPicker() 
    {
        if (this.DesignMode)
        {
            //These values are only set when the control is created in design mode
            this.tsMonthPicker.Month = System.DateTime.Now.Month;
            this.tsMonthPicker.Year = System.DateTime.Now.Year;
        }
    }
