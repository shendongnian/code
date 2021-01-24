    private Image setImage;
    private void Form1_Load(object sender, EventArgs e)
    {
        setImage = Image.FromFile("IMG_1612.png");
        pictureBox1.Image = setImage;
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        foreach (Circles element in _circles)
        {
            using (SolidBrush B = new SolidBrush(element.Color))
            {
                g.FillEllipse(B, element.Punt.X, element.Punt.Y, _CIRCLESIZE, _CIRCLESIZE);
            }                
        }
    }
