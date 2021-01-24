    public class MyShapes : Canvas
    {
        public MyShapes()
        {
            Background = Brushes.Transparent; // for mouse events to fire as expected.
            Ellipse elip = new Ellipse() { Fill = Brushes.Red, Width=40, Height=40 };
            SetLeft(elip, 50);
            SetTop(elip, 10);
            Children.Add(elip);
            elip.MouseEnter += E_MouseEnter;
            Ellipse elip2 = new Ellipse() { Fill = Brushes.Gray, Width = 40, Height = 40 };
            SetLeft(elip2, 600);
            SetTop(elip2, 400);
            Children.Add(elip2);
            elip2.MouseEnter += E_MouseEnter;
            Rectangle rect = new Rectangle() { Fill = Brushes.Blue, Width = 40, Height = 40 };
            SetLeft(rect, 260);
            SetTop(rect, 260);
            Children.Add(rect);
            rect.MouseEnter += E_MouseEnter;
            Rectangle rect2 = new Rectangle() { Fill = Brushes.Yellow, Width = 40, Height = 40 };
            SetLeft(rect2, 400);
            SetTop(rect2, 100);
            Children.Add(rect2);
            rect2.MouseEnter += E_MouseEnter;
        }
        private void E_MouseEnter(object sender, MouseEventArgs e)
        {
            SimpleCircleAdorner ad = new SimpleCircleAdorner((UIElement)sender, this); 
            AdornerLayer adLayer = AdornerLayer.GetAdornerLayer((UIElement)sender);
            adLayer.Add(ad);
        } 
        
    }
