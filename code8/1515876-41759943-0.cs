    private void moveDinos(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && titlePic.Visible == false)
            {
                if (_lturn != true)
                {
                    dino.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                    _lturn = true;
                }
                else
                {
                    dino.Left -= 100;
                }
            }
            else if (e.KeyCode == Keys.Right && titlePic.Visible == false)
            {
                if (lturn == true)
                {
                    dino.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                    _lturn = false;
                }
                    else
                {
                    dino.Left += 100;
                }
            }
        }
