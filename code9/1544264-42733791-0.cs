    public class MyForm {
        // A global variable to hold the position 
        private Rectangle _circleShape;
        // You can create this method via the Designer by
        //  double-clicking on the Form
        public void MyForm_Load(object sender, EventArgs e) {
            Random random = new Random();
            int x = random.Next(0, 400);
            int y = random.Next(0, 400);
            int width = 25; // fixed width
            int height = 25; //  and height
            
            // Assign the result to your "global" variable
            _circleShape = new Rectangle(x, y, width, height);
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            // Only do the actual "drawing" in this method
            e.Graphics.FillElipse(Brushes.Red, _circleShape);
        }
