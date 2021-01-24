    DoubleAnimation rotate = new DoubleAnimation();
            rotate.From = 0;
            rotate.To = 360;
            rotate.Duration = TimeSpan.FromSeconds(6);
           // rotate.RepeatBehavior=new RepeatBehavior(2.5);
            rotate.RepeatBehavior = RepeatBehavior.Forever;
            rotate3D.Axis = new Vector3D(0,1,1);
            rotate3D.Angle = 60;
            rotate3D.BeginAnimation(AxisAngleRotation3D.AngleProperty, rotate);
