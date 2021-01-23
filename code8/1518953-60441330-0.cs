int mouseX, mouseY;
        bool mouseM;
        private void panel7_MouseUp(object sender, MouseEventArgs e)
        {
            mouseM = false;
        }
        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            mouseM = true;
        }
        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseM)
            {
                SetDesktopLocation(MousePosition.X - mouseX, MousePosition.Y - mouseY);
            }
        }
