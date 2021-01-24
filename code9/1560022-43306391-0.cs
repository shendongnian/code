    private Timer m_Timer;
    private Form1() { // constructor
        m_Timer = new Timer(500); // updates progressbar every 500 ms
        progressBar1.Maximum = 5000; // MaxValue is reached after 5000ms
        m_Timer.Elapsed += async (s, e) => await mTimerTick();
    }
    
    private async Task mTimerTick() {
            progressBar1.Value += m_Timer.Interval;
            if (progressBar1.Value >= progressBar1.Maximum) {
                m_Timer.Stop();
                this.Hide();
                var f2 = new Form();
                f2.Show();
            }
    }
