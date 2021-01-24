    var anchor = new LiteralControl("<a href=\"#tabActivityInvoices\">Invoices (" + Company.Current.DefaultCurrency + ": " + Convert.ToDecimal(ds.Tables[1].Rows[0]["TotalRev"]) + ")</a>");
    var lnkButton = new LinkButton
    {
        ID = "btnLoadInvoice",
        CssClass = "btnListSmall",
        Width = new Unit("90px")
    };
    lnkButton.Click += btnInvoiceActivity_Click;
    liActivityInvoices.Controls.Add(anchor);
    liActivityInvoices.Controls.Add(lnkButton);
