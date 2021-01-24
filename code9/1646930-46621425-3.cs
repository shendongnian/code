    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    namespace WpfApp1
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Storyboard animation = new Storyboard();
        public MainWindow()
        {
            InitializeComponent();
            var mediaUri1 = new Uri(@"C:\MediaExamplesForWork\Sting - Sting At The Movies - 07 - Shape OF My Heart (Leon & Three Of Hearts).mp3");
            var mediaUri2 = new Uri(@"C:\MediaExamplesForWork\Desireless - Voyage Voyage.mp3");
            animation.Duration = TimeSpan.FromSeconds(20);
            var timeline1 = new MediaTimeline
            {
                Name = "a1",
                BeginTime = TimeSpan.Zero, 
                Duration = TimeSpan.FromSeconds(5),
                Source = mediaUri1,
                FillBehavior = FillBehavior.HoldEnd
            };
            Storyboard.SetTarget(timeline1, MediaElementObject1);
            animation.Children.Add(timeline1);
            
            var timeline2 = new MediaTimeline
            {
                Name = "a2",
                BeginTime = TimeSpan.FromSeconds(6),
                Duration = TimeSpan.FromSeconds(10),
                Source = mediaUri2,
                FillBehavior = FillBehavior.HoldEnd
            };
            Storyboard.SetTarget(timeline2, MediaElementObject2);
            animation.Children.Add(timeline2);
            
            animation.Begin();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            animation.SeekAlignedToLastTick(TimeSpan.FromSeconds(13));
        }
    }
    }
