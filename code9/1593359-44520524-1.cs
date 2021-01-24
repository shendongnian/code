            SizeF size;
            using (Graphics graphics = Grapics.FromImage(new Bitmap(1, 1)))
            {
                size = graphics.MeasureString(CustomTextBox.Text, new Font(CustomTextBox.FontFamily.ToString(),     Convert.ToSingle(CustomTextBox.FontSize), System.Drawing.FontStyle.Regular, GraphicsUnit.Pixel));
            }
 
            if (mousePoint.X >= size.Width) return CustomPasswordBox.Password.Length;
            else CustomTextBox.GetCharacterIndexFromPoint(mousePoint, true);
