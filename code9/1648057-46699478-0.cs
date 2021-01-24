    if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
    {
        //make move right true
        moveRight = true;
        //if i was going left,
        if (goingRight == false)
        {
            //say it im going right
            goingRight = true;
            //and flip it (only if i was going left before)
            picPlayer.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }
    }
