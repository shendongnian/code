    public class Form1
    {
        private MyCircle _circle;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           _circle.Draw(e); // this line causes the Circle object to draw itself on Form1's surface
        }
        public void MoveTheCircle(int xOffset, int yOffset)
        {
            _circle.X += xOffset; // make some changes that cause the circle to be rendered differently
            _circle.Y += yOffset;
            this.Invalidate(); // this line tells Form1 to repaint itself whenever it can
        }
    }
