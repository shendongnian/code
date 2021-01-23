    private void UltraGrid1_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
    {           
        if (Control.ModifierKeys != Keys.Shift && Control.ModifierKeys != Keys.Control)
        {
            e.Cancel = true;
        }
    }
