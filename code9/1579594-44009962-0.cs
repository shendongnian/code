    public partial class Form1 : Form
    {
        private MemoryStream _memoryStream = new MemoryStream();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string picturePath = @"c:\Users\IIG\Desktop\download.png";
            using (var fileStream = File.OpenRead(picturePath))
            {
                byte[] data = new byte[fileStream.Length];
                fileStream.Read(data, 0, data.Length);
                _memoryStream = new MemoryStream(data);
                pictureBox1.Image = Image.FromStream(_memoryStream);
            }
            MessageBox.Show("Picture loaded");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _memoryStream.Close();
                _memoryStream.Dispose();
            }
            catch (Exception exc)
            {
                //do some exception handling
            } 
        }
    }
