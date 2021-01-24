    protected override void OnMouseWheel(MouseEventArgs e)
        {
            
            if (e.Delta > 0 && ZoomFactor >MaxZoom)
            {
                ZoomFactor-=0.01;
            }
            else if (e.Delta < 0 && ZoomFactor <1 )
            {
                ZoomFactor += 0.01;
            }
    
            Rectangle srcRect = new Rectangle(0, 0, (int)(GridMap.Width * ZoomFactor), (int)(GridMap.Height * ZoomFactor));
            Bitmap cropped = ((Bitmap)GridMap).Clone(srcRect, MainGrid.Image.PixelFormat);
            MainGrid.Image = cropped;
        }
