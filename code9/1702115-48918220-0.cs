    //The Form is not Borderless
    LockFormRegionToControls(TestForm, false);
        public static void LockFormRegionToControls(Form f, bool IsBorderless) {
                LockBLFormRegionToControls<Control>(f, IsBorderless);
        }
        public static void LockBLFormRegionToControls<T>(Form f, bool Borderless) where T : Control
        {
            Region NewRegion;
            Point OffSet = Point.Empty;
            if (Borderless)
            {
                NewRegion = new Region();
            } else {
                OffSet = new Point((f.Bounds.Width - f.ClientSize.Width) / 2, f.Bounds.Height - f.ClientSize.Height);
                NewRegion = new Region(f.Bounds);
            }
            foreach (T ctrl in f.Controls.OfType<T>()) {
                Point p = new Point(ctrl.Bounds.Left + OffSet.X, ctrl.Bounds.Y + (OffSet.Y - OffSet.X));
                Size s = new Size(ctrl.Bounds.Width, ctrl.Bounds.Height);
                NewRegion.Union(new Region(new Rectangle(p, s)));
            }
            f.Region = NewRegion;
        }
