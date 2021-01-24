    bool isMouseDown = false;
    bool justDragged = false;
    private void button1_MouseDown(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Left) {
            isMouseDown = true;
            justDragged = false;
        }
    }
    private void button1_MouseMove(object sender, MouseEventArgs e) {
        if (isMouseDown) {
            //You then set your location of your control. See below:
            button1.Location = new Point(MousePosition.X, MousePosition.Y);
            justDragged = true;
        }
    }
    private void button1_MouseUp(object sender, MouseEventArgs e) {
        isMouseDown = false;
    }
    private void button1_Click(object sender, MouseEventArgs e) {
        if (!justDragged) { // then we clicked
            // do click handling
        }
    }
