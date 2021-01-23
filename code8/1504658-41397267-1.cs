    public class YourForm : Form
    {
        private readonly BindingList<Receipt> _Receipts;
        public YourForm()
        {
            _Receipts = new BindingList<Receipt>();
            listBox1.DisplayMember = "Info";
            listBox1.DataSource = _Receipts;        
        }
        private void AddToList(object sender, EventArgs e)
        {
            var button = (Button) sender;
            var product = (Product) button.Tag;
            var receiptInfo = _Receipts.FirstOrDefault(receipt => receipt.Name.Equals(product.Name));
            if (receiptInfo == null)
            {
                receiptInfo = new Receipt(product.Name, product.Cmimi, txtNrbill.Text);
                _Receipts.Add(receiptInfo);
            }
            else
            {
                receiptInfo.AddOne();
            }
        }
    }
