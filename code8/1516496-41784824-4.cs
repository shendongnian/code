        public partial class Form1 : Form
        {
            private Mp3Player _mp3Player = new Mp3Player(@"C:\music.mp3");
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                _mp3Player.Play();
            }
    
           
            private void trackBarVolume_Scroll(object sender, EventArgs e)
            {
                _mp3Player.SetVolume(trackBarVolume.Value);
            }
        }
    
