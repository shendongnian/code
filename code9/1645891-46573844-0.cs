    private void MovePlayer(int offset)
    {
        //move right
        if (stopThePlayer == true)
        {
            return;
        }
        else
        {
            x = x + offset;
            RightBoundary();
            MovingSubprograms();
        }
    }
    private void btnRight_Click(object sender, EventArgs e)
    {
       MovePlayer(speed);
    }
    private void btnLeft_Click(object sender, EventArgs e)
    {
       MovePlayer(speed*-1);
    }
