        private void moveCtlToTarget()
        {
            Control Target = Parent;
            while (Target.Parent != null)
                Target = Target.Parent;
            Point pt = CheckBox.PointToScreen(Point.Empty);
            CheckBox.Location = Target.PointToClient(pt);
            CheckBox.Parent = Target;
            CheckBox.BringToFront();
        }
