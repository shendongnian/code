    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Interactivity;
    using System.Windows.Shapes;
    
    namespace gierkaPierwszy.Zachowania
    {
        public class Zachowania : Behavior<Window>
        {
            public static readonly DependencyProperty SpaceShipProperty 
                = DependencyProperty.Register("SpaceShip", typeof(Rectangle), typeof(Zachowania), new FrameworkPropertyMetadata(null));
            public Rectangle SpaceShip
            {
                set { SetValue(SpaceShipProperty, value); }
                get { return (Rectangle)GetValue(SpaceShipProperty); }
            }
            protected override void OnAttached()
            {
                base.OnAttached();
                AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown; 
            }
            private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
            {
                if (SpaceShip == null) return;
                switch (e.Key)
                {
                    case Key.Left:
                        if (Canvas.GetLeft(SpaceShip) > 0) Canvas.SetLeft(SpaceShip, Canvas.GetLeft(SpaceShip) - 1);
                        break;
                    case Key.Right: Canvas.SetLeft(SpaceShip,Canvas.GetLeft(SpaceShip) + 1);
                        break;
                    case Key.Up:
                        if (Canvas.GetTop(SpaceShip) > 0) Canvas.SetTop(SpaceShip, Canvas.GetLeft(SpaceShip) - 1);
                        break;
                    case Key.Down:
                         Canvas.SetTop(SpaceShip, Canvas.GetTop(SpaceShip) + 1);
                        break;
                    default:
                    return;
            }
        }
    }
