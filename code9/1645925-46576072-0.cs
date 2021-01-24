    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (isMoving)
        {
            if (pictureBox1.Image == null) e.Graphics.Clear(Color.White);
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
            _Pen = new Pen(Color.IndianRed, 3);
            _Pen.CustomEndCap = bigArrow;
            e.Graphics.DrawLine(_Pen, mouseDownPosition, mouseMovePosition);
            _Pen.Dispose();
        }
    }
