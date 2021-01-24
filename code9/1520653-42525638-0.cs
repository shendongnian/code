            var Ellipse1 = new Ellipse();
            Ellipse1.Fill = new SolidColorBrush(Windows.UI.Colors.Transparent);
            Ellipse1.Stroke = new SolidColorBrush(Windows.UI.Colors.DarkGreen);
            Ellipse1.Width = radius * 2; //Diameter is twice the radius
            Ellipse1.Height = radius * 2;
            Ellipse1.SetValue(Canvas.LeftProperty, System.Convert.ToDouble(x)); //X value
            Ellipse1.SetValue(Canvas.TopProperty, System.Convert.ToDouble(y)); //Y value
            layoutRoot.Children.Add(Ellipse1); //Add the circle to the page. Could also use a canvas in place of layoutRoot.
