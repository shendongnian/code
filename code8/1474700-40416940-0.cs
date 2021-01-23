    this.cmb.InitializeLayout += Cmb_InitializeLayout;
    
    private void Cmb_InitializeLayout(object sender, InitializeLayoutEventArgs e)
    {
        foreach(var col in e.Layout.Bands[0].Columns)
        {
            if(col.Header.Caption != "valueColumn")
            {
                col.Hidden = true;
            }
        }
    }
