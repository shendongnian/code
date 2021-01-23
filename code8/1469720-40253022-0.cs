public void WriteTextToImage(Point position)
        {
           SolidColorBrush brush = new SolidColorBrush((Color)cpColor.SelectedColor);
            //Get something to write on (not an old receipt...)
            TextBlock textBlock = new TextBlock();
            //Say something useful... well something atleast...
            textBlock.Text = tbCurrentLabel.Text;
            textBlock.FontSize = slFontSize.Value;
            textBlock.Foreground = brush;
            Canvas.SetLeft(textBlock, position.X);
            Canvas.SetTop(textBlock, position.Y);
            canvas.Children.Add(textBlock);
            //Need to update the canvas, was not seeing children before doing this.
            canvas.UpdateLayout();
`            
            //Iterate the label text
            IterateLabel();
        }
