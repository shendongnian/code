        public static void OverlayControl(ImageSource first, CustomControl CC)
        {
            if (CC == null)
                return;
            var visual = new DrawingVisual();
            double left = Canvas.GetLeft(CC);
            double top = Canvas.GetTop(CC);
            // Get control's angle.
            double rotationInDegrees = 0.0f;
            RotateTransform rotation = CC.RenderTransform as RotateTransform;
            if (rotation != null) // Make sure the transform is actually a RotateTransform
            {
                rotationInDegrees = rotation.Angle; // back up this to temp var.
                rotation.Angle = 0.0f; // Set this to 0.0 to capture properly.
            }
            
            var second = ControlToBitmap(CC);
            using (var dc = visual.RenderOpen())
            {
                // Draw the background image frist.
                dc.DrawImage(first, new Rect(0, 0, first.Width, first.Height));
                // Push angle if the control has rotated.
                if (rotationInDegrees != 0.0f)
                    dc.PushTransform(new RotateTransform(rotationInDegrees, left + (CC.Width / 2), top + (CC.Height / 2)));
                
                // transfrom as much as control moved from the origin.
                dc.PushTransform(new TranslateTransform(left, top));
                // Draw the second image. (captured image from the control)
                dc.DrawImage(second, new Rect(0, 0, second.Width, second.Height));
                // pop transforms
                dc.Pop();
            }
            var rtb = new RenderTargetBitmap((int)first.Width, (int)first.Height,
                                        96, 96, PixelFormats.Default);
            rtb.Render(visual);
            // Set as a one combined image.
            MainWindow.VM.RenderedImage = rtb;
        }
