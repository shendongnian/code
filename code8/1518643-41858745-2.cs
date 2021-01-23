        public void checkForColorDifference(Color start)
        {
            Color starting = start;
            Color currentColor = GetPixelColor(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
            if (starting != currentColor)
            {
                timer1.Enabled = false;
                MessageBox.Show("Color: " + start + " changed to:" + currentColor.ToString() + ".", "Color change response");
                startingColor = currentColor;
                timer1.Enabled = true;
            }
        }
