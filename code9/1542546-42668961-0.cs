    Timer m_Timer = null; // placeholder for your timer
    private void panel1_MouseClick(object sender, MouseEventArgs e)
    {
        if(m_Timer != null) return; 
        // if timer is not null means you're animating your panel so do not want to perform any other animations
        m_Timer = new Timer(); //  instantiate timer
        m_Timer.Interval = 1000 / 30; // 30 frames per second;
        m_Timer.Tick += OnTimerTick; // set method handler
        m_Timer.Start(); // start the timer
    }
    int m_CurrentFrame = 0; // current frame 
    void OnTimerTick(object sender, EventArgs e)
    {
        const int LAST_FRAME_INDEX = 150; // maximum frame you can reach
        if(m_CurrenFrame > LAST_FRAME_INDEX) // if max reached
        {
            m_Timer.Stop();  // stop timer
            m_Timer.Dispose(); // dispose it for the GC
            m_Timer = null; // set it's reference to null
            m_CurrentFrame = 0; // reset current frame index
            return; // return from the event
        }
        this.Invoke(new MethodDelegate( () => { // invoke this on the UI thread
            panel1.Location = new Point(panel1.Location.X - m_CurrenFrame, panel1.Location.Y); 
        });
        m_CurrentFrame++; // increase current frame index
    }
