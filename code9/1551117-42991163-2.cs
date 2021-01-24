    // Page_Load is just an example event here, change to any event you need
    protected void Page_Load(object sender, EventArgs e)
    {
        DetailsView dv = sender as DetailsView;
        // the checkbox uses checked state as its value to be passed
        // n = row/cell/control indexes where CheckBoxField has bound into, starting from 0
        // e.g. dv.Rows[0].Cells[0].Controls[0] as CheckBox
        bool checkboxvalue = (dv.Rows[n].Cells[n].Controls[n] as CheckBox).Checked;
    }
