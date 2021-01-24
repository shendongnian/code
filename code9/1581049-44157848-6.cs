    public int a = 0 ;` 
    public int c = 0;  
    public delegate void UpdateControlsDelegate(); //Execute when video loads
    public formdeneme()
    {
        InitializeComponent();
        myVlcControl.Play("file:///C:/Users/1315k/Downloads/machine.mp4");           
        // You can add your media like above.
        //Event handler for 'current media time' label
        this.vlcControl1.PositionChanged += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPositionChangedEventArgs>(this.vlcControl1_PositionChanged);
        //Event handler for setting trackBar1.Maximum on media load
        vlcControl1.Playing += new System.EventHandler<VlcMediaPlayerPlayingEventArgs>(SetProgresMax);
    }
    
    // This is the main function which you looking.
    private void trackBar1_Scroll(object sender, EventArgs e)
    {                        
        myVlcControl.myVlcMediaPlayer.Time = trackBar1.Value * 1000;
        int b = (int)myVlcControl.myVlcMediaPlayer.Time / 1000;
        int d = b / 60;
        b = b - d * 60;
        label1.Text = d+":"+b + "/"+ c + ":" + a;
        // The Time value is milisecond, you have divide 1000 for be second.
    }
    
    private void formdeneme_Load(object sender, EventArgs e)
    {
        a = (int)myVlcControl.myVlcMediaPlayer.Length / 1000;           
        trackBar1.Maximum = a;  
        c = a / 60;
        a = a - c * 60;        
        label1.Text = 0 + "/" + c+":"+a;            
    }
