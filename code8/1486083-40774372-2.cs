    public partial class MainWindow : Window
    {
        public Random Rng { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Rng = new Random(0);
            do
            {
                AddBoxToRandomPointInPlayArea();
            } while (PlayArea.Children.Count < 10);
            
        }
        private void AddBoxToRandomPointInPlayArea()
        {
            var x = Rng.Next(0, Convert.ToInt32(PlayArea.Width));
            var y = Rng.Next(0, Convert.ToInt32(PlayArea.Height));
            var box = new Rectangle
            {
                Height = 10,
                Width = 30,
                Fill = Brushes.Brown
            };
            PlayArea.Children.Add(box);
            Canvas.SetLeft(box, x);
            Canvas.SetTop(box, y);
        }
        private void PlayArea_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var x = Canvas.GetLeft(Bee);
            var y = Canvas.GetTop(Bee);
            var storyboard = new Storyboard();
            var xTranslation = new DoubleAnimation(x, e.GetPosition(PlayArea).X, new Duration(new TimeSpan(0, 0, 5)));
            Storyboard.SetTargetProperty(xTranslation, new PropertyPath(Canvas.LeftProperty));
            xTranslation.CurrentTimeInvalidated += CheckForCollidingBoxesAndRemoveIfNeeded;
            storyboard.Children.Add(xTranslation);
            var yTranslation = new DoubleAnimation(y, e.GetPosition(PlayArea).Y, new Duration(new TimeSpan(0, 0, 5)));
            Storyboard.SetTargetProperty(yTranslation, new PropertyPath(Canvas.TopProperty));
            yTranslation.CurrentTimeInvalidated += CheckForCollidingBoxesAndRemoveIfNeeded; 
            storyboard.Children.Add(yTranslation);
            Bee.BeginStoryboard(storyboard);
        }
        private void CheckForCollidingBoxesAndRemoveIfNeeded(object sender, EventArgs eventArgs)
        {
            var idxToRemoveAt = GetIndexOfBoxCollidingWithBee;
            if ( idxToRemoveAt != -1 )
            {
                PlayArea.Children.RemoveAt(idxToRemoveAt);
            }
        }
        /// <summary>
        /// returns 0 if no boxes collide, otherwise the number is the index of the box in the 
        /// </summary>
        public int GetIndexOfBoxCollidingWithBee
        {
            get
            {
                var beeTopLeft = PointToScreen(new Point(Canvas.GetLeft(Bee), Canvas.GetTop(Bee))); // local to world coordinates
                var beeCentroid = new Point((beeTopLeft.X + Bee.ActualWidth) * 0.5, (beeTopLeft.Y + Bee.ActualHeight) * 0.5); // center point of bee
                for (var idx = 0; idx < PlayArea.Children.Count; idx++)
                {
                    var child = PlayArea.Children[idx];
                    var currentBoxInSearch = child as Rectangle;
                    if (currentBoxInSearch != null)
                    {
                        var boxTopLeft = PointToScreen(new Point(Canvas.GetLeft(currentBoxInSearch), Canvas.GetTop(currentBoxInSearch))); // local to world coordinates
                        var boxCentroid = new Point((boxTopLeft.X + currentBoxInSearch.ActualWidth) * 0.5, (boxTopLeft.Y + currentBoxInSearch.ActualHeight) * 0.5); // center point of bee
                        var xCollided = false;
                        var yCollided = false;
                        if (Math.Abs(beeCentroid.X - boxCentroid.X) < Bee.ActualWidth*0.5)
                            xCollided = true;
                        if (Math.Abs(beeCentroid.Y - boxCentroid.Y) < Bee.ActualHeight*0.5)
                            yCollided = true;
                        if (xCollided && yCollided)
                            return idx;
                    }
                }
                return -1;
            }
        }
    }
