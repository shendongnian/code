    using System.Windows.Forms;
    using System.IO;
    using System.Windows.Media.Imaging;
    
    namespace WindowsFormsApplication1
        {
        public partial class Form1 : Form
            {
            public Form1()
                {
                InitializeComponent();
                }
    
            private void button1_Click(object sender, EventArgs e)
                {
                using (Stream strm = File.OpenRead("someimage.jpg"))
                    {
                    BitmapFrame frame = BitmapFrame.Create(strm, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.None);
                    }
    
                }
            }
        }
