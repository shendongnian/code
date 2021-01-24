    var anchor = new LiteralControl("<a href=\"#tabActivityInvoices\">Invoices (" + Company.Current.DefaultCurrency + ": " + Convert.ToDecimal(ds.Tables[1].Rows[0]["TotalRev"]) + ")</a>");
    var lnkButton = new LinkButton
    {
        ID = "btnLoadInvoice",
        OnClientClick = "btnInvoiceActivity_Click",
        CssClass = "btnListSmall",
        Width = new Unit("90px")
    };
    liActivityInvoices.Controls.Add(anchor);
    liActivityInvoices.Controls.Add(lnkButton);
