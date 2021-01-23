    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private async void Form1_Load(Object sender, EventArgs e)
        {
            label1.Text = "0 %";
            progressBar1.Minimum = 0;
            progressBar1.Maximum = ExtractImages.imagesUrls.Count() - 1;
            await DoWork();
        }
    
        private async Task DoWork()
        {
            for (int i = 0; i < ExtractImages.imagesUrls.Count(); i++)
            {
                using (var client = new WebClient())
                {
                    await client.DownloadFileTaskAsync(ExtractImages.imagesUrls[i], @"C:\Temp\TestingSatelliteImagesDownload\" + i + ".jpg");
    
                    progressBar1.Value = i;
                    double average = (double)i / ExtractImages.imagesUrls.Count();
                    label1.Text = (average * 100).ToString() + " %";
                }
            }
        }
    }
