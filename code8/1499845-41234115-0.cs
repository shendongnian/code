    class GeneratePoints 
    {
        ...
        public void Draw(PictureBox pictureBox)
        {
            using (Graphics g = Graphics.FromHwnd(pictureBox.Handle))
            {
                foreach (var p in points)
                {
                    //Draw the point
                }
            }
        }
    }
