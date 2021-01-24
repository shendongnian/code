    public partial class QRCode : Form
    {
        [SerializableAttribute]
        [ComVisibleAttribute(true)]
        public class ArgumentNullException : ArgumentException { }
        MySqlConnection connection = new MySqlConnection("server=sql12.freemysqlhosting.net; port=3306; user id=sql12192362; password= DtxpressProject25!; persistsecurityinfo=False;database=sql12192362");
        MySqlCommand command;
        public QRCode()
        {
            InitializeComponent();
        }
        private void btn_gen_Click(object sender, EventArgs e)
        {
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            pictureBox1.Image = qrcode.Draw(textBox1.Text, 50);
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "PNG(*.PNG)|*.png";
            if (f.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(f.FileName);
                MessageBox.Show("QR Code has been successfully saved.");
            }
        }
        private void btn_sve_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            byte[] img = ms.ToArray();
            string fn = AddDriver.qnum.ToString();
            String insertQuery = "Update driver set QrCode = '" + @img + "' where FranchiseNumber= '"+fn+"'";
            connection.Open();
            command = new MySqlCommand(insertQuery, connection);
            command.Parameters.Add("@img", MySqlDbType.Blob);
            command.Parameters["@img"].Value = img;
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Driver has been added.");
            }
            connection.Close();
            AddDriver back = new AddDriver();
            back.Show();
            this.Hide();
        }
