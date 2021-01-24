    public partial class QRCode : Form
    {
 
       // Image file;
        [SerializableAttribute]
        [ComVisibleAttribute(true)]
        public class NullReferenceException : SystemException
        {
        }
        public QRCode()
        {
            InitializeComponent();
            textBox1.Text = AddDriver.qnum;
            //textBox1.Text = "hello";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            pictureBox1.Image = qrcode.Draw(textBox1.Text, 50);
        }
        private void btn_sve_Click(object sender, EventArgs e)
        {
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "PNG(*.PNG)|*.png";
            if (f.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(f.FileName);
                //file.Save(f.FileName);
                MessageBox.Show("QR Code has been successfully saved.");
                
                AddDriver back = new AddDriver();
                back.Show();
                this.Hide();
            }
        }
