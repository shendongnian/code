      public partial class MainWindow : Window
    {
        private Storyboard s;
        public MainWindow()
        {
            InitializeComponent();
            Button button = new Button();
            button.Height = 28;
            button.Width = 58;
            button.HorizontalAlignment = HorizontalAlignment.Center;
            button.VerticalAlignment = VerticalAlignment.Center;
            button.Content = "Button";
            button.Name = "button";
            this.RegisterName(button.Name, button);
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 100;
            rectangle.Height = 100;
            rectangle.Fill = new SolidColorBrush(Colors.White);
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            Canvas.SetLeft(rectangle, 10);
            Canvas.SetTop(rectangle,10);
            canvas1.Children.Add(rectangle);
            rectangle.Name = "rectangle";
            TranslateTransform tt = new TranslateTransform();
            ScaleTransform st = new ScaleTransform();
        
            TransformGroup tg = new TransformGroup();
            tg.Children.Add(tt);
            tg.Children.Add(st);
            button.RenderTransform = tg;
            
            Duration duration = new Duration(TimeSpan.FromMilliseconds(10));
            DoubleAnimationUsingKeyFrames myDoubleAnim = new DoubleAnimationUsingKeyFrames();
            EasingDoubleKeyFrame myDoubleKey = new EasingDoubleKeyFrame();
            
            Storyboard s = new Storyboard();
            Storyboard.SetTargetName(myDoubleAnim, button.Name);
            Storyboard.SetTargetProperty(myDoubleAnim, new PropertyPath("RenderTransform.Children[3].Y"));
            myDoubleKey.KeyTime = KeyTime.FromPercent(1);
            myDoubleKey.Value = 300;
            myDoubleAnim.KeyFrames.Add(myDoubleKey);
            s.Children.Add(myDoubleAnim);
       
            s.Begin(rectangle);
            //button.Loaded += new RoutedEventHandler(buttonLoaded);
      
        }
