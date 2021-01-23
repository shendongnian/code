    private bool _facingLeft;   // initial state of the image must match with this boolean.
    private void moveDinos(object sender, KeyEventArgs e)
    {
        // this shoudn't depend on the visible state of the title!!! you should change it.
        if(titlePic.Visible)
            return;
 
        // check the keys if the left or right key is pressed.
        if((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Right))
        {
            // when the left button is pressed, it should face left..
            bool shouldFaceLeft = (e.KeyCode == Keys.Left);
            // if the current state of the image facing left?
            if(_facingLeft != shouldFaceLeft)
            {   
                // if not, flip the image.
                dino.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            }
            else
                // move the dino..
                if(shouldFaceLeft)
                    dino.Left -= 100;
                else
                    dino.Left += 100;
        }
    }
