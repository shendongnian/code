        for (int i = 0; i < points.Count; i++)
        {
            using (TextureBrush tbr = new TextureBrush(image))
            {
                tbr.RotateTransform(i * 4);   // optional
                var p = PointToClient(Cursor.Position);
                tbr.Transform = new Matrix(
                    scaleX,
                    0.0f,
                    0.0f,
                    scaleY,
                    0.0f,
                    0.0f);
                // any tile mode will work, though not all the same way
                tbr.WrapMode = WrapMode.TileFlipXY;
                if (cbx_tileFunny.Checked)
                    e.Graphics.FillEllipse(tbr, p.X - diameter/2, 
                                                p.Y - diameter/2, diameter, diameter);
                else
                {
                   ((Bitmap)image).SetResolution(e.Graphics.DpiX, e.Graphics.DpiY);   // (**)
                    e.Graphics.ScaleTransform(scaleX, scaleY);
                    e.Graphics.DrawImage( image, (p.X - diameter/2) / scaleX,
                                                 (p.Y - diameter/2 ) / scaleY);
                    e.Graphics.ResetTransform();
                }
                    Pen p3 = new Pen(tbr);
                    e.Graphics.DrawEllipse(Pens.DeepSkyBlue, p.X - diameter/2,
                                           p.Y - diameter/2, diameter, diameter);
            }
        }
