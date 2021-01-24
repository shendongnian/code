    TextBox txtEno = (TextBox)GridEmp.FooterRow.FindControl("txtEmpNo");
    int eNo;
    bool eNoIsValid = int.TryParse(txtEno.Text, out eNo);
    if (!eNoIsValid)
    {
        // Handle invalid input.
    }
