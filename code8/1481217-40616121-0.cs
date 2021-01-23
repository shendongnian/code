    namespace YourNamespace
    {
        public class YourClass
        {
            List<SkuBar> SKUS;
            public YourClass() // Or form load or whatever
            {
                SKUS = new List<SkuBar>();
            }
            protected void btnAddSkuBarcode_Click(object sender, EventArgs e)
            {
                SKUS.Add(new SkuBar {SkuBarcode = txtSkuBarcode.Text , Qty = txtQty.Text});
                lvWebLabels.DataSource = SKUS;
                lvWebLabels.DataBind();
            }
        }
    }
