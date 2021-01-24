    public formdeneme()
        {
            InitializeComponent();
            m_mediaControl1.Play("file:///C:/Users/1315k/Downloads/machine.mp4");           
            
        }
    private void trackBar1_Scroll(object sender, EventArgs e)
        {                        
            m_mediaControl1.m_MediaPlayer.Time = trackBar1.Value * 1000;
            int b = (int)m_mediaControl1.m_MediaPlayer.Time / 1000;
            label1.Text = b + "/" + a;
        }
    private void formdeneme_Load(object sender, EventArgs e)
        {
             a = (int)m_mediaControl1.m_MediaPlayer.Length / 1000;           
            trackBar1.Maximum = a;          
            label1.Text = 0 + "/" + a;     
            
        }
