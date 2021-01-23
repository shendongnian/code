    private Bitmap CropImage(Image originalImage, Rectangle sourceRectangle,
                        Rectangle? destinationRectangle = null)
        {
            if (destinationRectangle == null)
            {
                destinationRectangle = new Rectangle(Point.Empty, sourceRectangle.Size);
            }
            var croppedImage = new Bitmap(destinationRectangle.Value.Width,
                destinationRectangle.Value.Height);
            using (var graphics = Graphics.FromImage(croppedImage))
            {
                graphics.DrawImage(originalImage, destinationRectangle.Value,
                    sourceRectangle, GraphicsUnit.Pixel);
            }
            return croppedImage;
        }
        /// <summary>
        /// Button click to choose an image and test
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCrop_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string imageFile = ofd.FileName;
                Image img = new Bitmap(imageFile);
                Rectangle source = new Rectangle(0, 0, 120, 20);
                Image cropped = CropImage(img, source);
                // Save cropped image here
                cropped.Save(Path.GetDirectoryName(imageFile) + "\\croppped." + Path.GetExtension(imageFile));
            }
        }
