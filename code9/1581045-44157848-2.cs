    public int a = 0 ;`   
    public formdeneme()
            {
                InitializeComponent();
                m_mediaControl1.Play("file:///C:/Users/1315k/Downloads/machine.mp4");           
                // You can add your media like above.
            }
    
        // This is the main function which you looking.
        private void trackBar1_Scroll(object sender, EventArgs e)
            {                        
                m_mediaControl1.m_MediaPlayer.Time = trackBar1.Value * 1000;
                int b = (int)m_mediaControl1.m_MediaPlayer.Time / 1000;
                label1.Text = b + "/" + a;
                // The Time value is milisecond, you have divide 1000 for be second.
            }
    
        private void formdeneme_Load(object sender, EventArgs e)
            {
                 a = (int)m_mediaControl1.m_MediaPlayer.Length / 1000;           
                trackBar1.Maximum = a;          
                label1.Text = 0 + "/" + a;     
                
            }
