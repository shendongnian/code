    public partial class MainWindow : Window
    {
    
        private Stopwatch timer = new Stopwatch();
        private static readonly double powerFactor = .3;
        private Storyboard storyboard;
        private PowerEase easingFunction;
    
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new ViewModel();
            //handle the completed event to re-execute the storyboard
            this.storyboard = this.Resources["Storyboard1"] as Storyboard;
            this.storyboard.Completed += Storyboard_Completed;
    
            //get the animation to locate our easing function defined in xaml.
            var animation = storyboard.Children[0] as ColorAnimationUsingKeyFrames;
                
            //find the second keyframe, thats the one that has easing function.
            this.easingFunction = (animation.KeyFrames[1] as EasingColorKeyFrame).EasingFunction as PowerEase;
    
    
        }
    
        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.timer.Reset();
            this.timer.Start();
            this.easingFunction.Power = 0;
                           
            RunStoryboard();
        }
    
        private void Storyboard_Completed(object sender, EventArgs e)
        {
            if (timer.ElapsedMilliseconds < 6000)
            {
                RunStoryboard();
            }
        }
    
        private void RunStoryboard()
        {
            this.easingFunction.Power += powerFactor;
            storyboard.Begin();
        }
    }
