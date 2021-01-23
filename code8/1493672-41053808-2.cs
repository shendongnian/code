    public sealed partial class MainPage : Page
    {
        private SimpleOrientationSensor simpleorientation;
        private double? Current = 0;
    
        public MainPage()
        {
            this.InitializeComponent();
            simpleorientation = SimpleOrientationSensor.GetDefault();
            if (simpleorientation != null)
            {
                simpleorientation.OrientationChanged += new TypedEventHandler<SimpleOrientationSensor, SimpleOrientationSensorOrientationChangedEventArgs>(OrientationChanged);
            }
        }
    
        private async void OrientationChanged(SimpleOrientationSensor sender, SimpleOrientationSensorOrientationChangedEventArgs args)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                SimpleOrientation orientation = args.Orientation;
                switch (orientation)
                {
                    case SimpleOrientation.NotRotated:
                        Rotate(0);
                        break;
    
                    case SimpleOrientation.Rotated90DegreesCounterclockwise:
                        Rotate(90);
                        break;
    
                    case SimpleOrientation.Rotated180DegreesCounterclockwise:
                        Rotate(180);
                        break;
    
                    case SimpleOrientation.Rotated270DegreesCounterclockwise:
                        Rotate(270);
                        break;
    
                    case SimpleOrientation.Faceup:
                        break;
    
                    case SimpleOrientation.Facedown:
                        break;
    
                    default:
    
                        break;
                }
            });
        }
    
        private void Rotate(double value)
        {
            MyAnimation.From = Current;
            MyAnimation.To = (360 - value);
            myStoryBoard.Begin();
            Current = MyAnimation.To;
        }
    }
