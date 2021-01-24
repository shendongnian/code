    public partial class MainWindow : Window
    {
        private readonly Queue<string> _audioFilesQueue = new Queue<string>();
        private readonly MediaElement _player;
    
        public MainWindow()
        {
            InitializeComponent();
    
            _player = new MediaElement();
            _player.LoadedBehavior = MediaState.Manual;
            _player.UnloadedBehavior = MediaState.Manual;
            _player.MediaEnded += Player_MediaEnded;
        }
    
        private void Player_MediaEnded(object sender, RoutedEventArgs e)
        {
            OnProcessQueue();
        }
    
        private void Btn_OnClick(object sender, RoutedEventArgs e)
        {
            PlayCascade(new[]
            {
                "X:\\Library\\Sounds\\Other\\sound1.wav",
                "X:\\Library\\Sounds\\Other\\sound2.wav",
                "X:\\Library\\Sounds\\Other\\sound3.wav"
            });
        }
    
        private void PlayCascade(string[] sequence)
        {
            foreach (var file in sequence)
            {
                _audioFilesQueue.Enqueue(file);
            }
            OnProcessQueue();
        }
    
        private void OnProcessQueue()
        {
            Dispatcher.Invoke(() =>
            {
                if (_audioFilesQueue.Any())
                {
                    var toPlay = _audioFilesQueue.Dequeue();
                    _player.Source = new Uri(toPlay);
                    _player.Play();
                }
            });
        }
