    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Size sz = pictureBox1.ClientSize;
        DrawSpiral(2, 5, SpiralType.FermaPlus, Color.Blue, g, sz);
        DrawSpiral(2, 5, SpiralType.FermaMinus, Color.Red, g, sz);
    }
