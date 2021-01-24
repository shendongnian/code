    public void My_Paint(object sender, PaintEventArgs e)
    {
        double elapsed = DateTime.Now.Subtract(animationStarted).TotalMilliseconds;
        // ... current paint code
    
        if (Car_move)
        {
            Invalidate();
        }
    }
