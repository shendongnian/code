        private void cvsMap_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double ratio = imgMap.ImageSource.Width / imgMap.ImageSource.Height;
            foreach (Control ctrl in cvsMap.Children)
            {
                if (ctrl is Button)
                {
                    newBtnPosition((Button)ctrl, ratio, e);
                }
            }
        }
        /// <summary>
        /// Assign a new position to a ctrl contained into a canvas
        /// </summary>
        /// <param name="ctrl">control to modify</param>
        /// <param name="ratio">ratio of the reference element</param>
        /// <param name="e">SizeChanged of the container</param>
        private void newBtnPosition(Control ctrl, double ratio, SizeChangedEventArgs e)
        {
            //Everythong is computed according to the reference element (ImageBrush)
            Size oldImgSize, newImgSize;
            //Avoid dividing by 0
            if (e.PreviousSize.Width * e.PreviousSize.Height * e.NewSize.Width * e.NewSize.Height == 0) { return; }
            oldImgSize = RefSize(ratio, e.PreviousSize);
            newImgSize = RefSize(ratio, e.NewSize);
            Point oldImgPos, newImgPos;
            oldImgPos = new Point((e.PreviousSize.Width - oldImgSize.Width) / 2, (e.PreviousSize.Height - oldImgSize.Height) / 2);
            newImgPos = new Point((e.NewSize.Width - newImgSize.Width) / 2, (e.NewSize.Height - newImgSize.Height) / 2);
            //Retrieve the position of the control according to the ref element
            Point ctrlPos = new Point((double)ctrl.GetValue(Canvas.LeftProperty) - oldImgPos.X,
                                     (double)ctrl.GetValue(Canvas.TopProperty) - oldImgPos.Y);
            //Compute the new position according to the reference element
            ctrlPos.X*=newImgSize.Width / oldImgSize.Width;
            ctrlPos.Y *= newImgSize.Height / oldImgSize.Height;
            //Assign the new position according to the Canvas
            ctrl.SetValue(Canvas.LeftProperty, ctrlPos.X + newImgPos.X);
            ctrl.SetValue(Canvas.TopProperty, ctrlPos.Y + newImgPos.Y);
        }
        /// <summary>
        /// Compute a element size, given a aspect ratio, a container size, and a Stretch="Uniform" behavior
        /// </summary>
        /// <param name="ratio">aspect ratio of the control</param>
        /// <param name="containerSize">container size of the control</param>
        /// <returns>new size</returns>
        private Size RefSize(double ratio, Size containerSize)
        {
            double cH, cW;
            cW = containerSize.Width;
            cH = containerSize.Height;
            if (cH * cW == 0) { return new Size(0, 0); }
            if (cW / cH  > ratio)
            {
                return new Size(cH * ratio, cH);
            }
            else
            {
                return new Size(cW, cW/ratio);
            }
        }
