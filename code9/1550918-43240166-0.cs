    private void dtpFormat(object sender, ConvertEventArgs e)
    {
        Binding b = sender as Binding;
        if(b != null)
        {
            DateTimePicker dtp = (b.Control as DateTimePicker);
            if (dtp != null)
            {
                if (e.Value == null || e.Value == DBNull.Value)
                {
                    dtp.Checked = false;
                    dtp.CustomFormat = " ";
                    // e.Value = false;
                    // To prevent dtp.Value property setter setting Checked back to true
                    e.Value = dtp.Value; 
                }
                else
                {
                    dtp.Checked = true;
                    dtp.CustomFormat = "dd-MMM-yyyy";
                    //dtp.Value = (DateTime) e.Value;                    
                    // dtp.Value will be set to e.Value from databinding anyway
                }
            }
        }
    }
    private void dtpParse(object sender, ConvertEventArgs e)
    { 
        Binding b = sender as Binding;
        if (b != null)
        {
            DateTimePicker dtp = (b.Control as DateTimePicker);
            if (dtp != null)
            {
                if (dtp.Checked == false)
                {
                    e.Value = DBNull.Value;
                }
                else
                {
                    //e.Value = dtp.Value;
                    // Do nothing, e.Value is already populated with dtp.Value
                }
            }
        }
    }
