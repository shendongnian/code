    private void frmpaymentsearch_Load(object sender, EventArgs e)
    {
        txtcomvalue.Text = "PaymentVoucherCode";
        dllby.DisplayMember = "Text";
        dllby.ValueMember = "Value";
        dllby.Items.Add(new ComboboxItem(){ Text = "P.Voucher Code", Value = "PaymentVoucherCode" });
        dllby.Items.Add(new ComboboxItem(){ Text = "Vendor", Value = "VendorName" });
        dllby.SelectedIndex = 0;
    }
    private void dllby_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtcomvalue.Text = (dllby.SelectedItem as ComboboxItem).Value.ToString();
    }
    public class ComboboxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
    
        public override string ToString()
        {
            return Text;
        }
    }
