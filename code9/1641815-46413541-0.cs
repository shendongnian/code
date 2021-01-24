     class Watcher
    {
        public string mainText;
        void StoryMode()
        {
            mainText = "Example Text";
        }
    }
        public partial class MainWindow : Window
    {
        string texblock_story_text;
        public MainWindow()
        {
            InitializeComponent();          
        }
           
        void Get_Text()
        {
            Watcher MyWatcher = new Watcher();
            texblock_story_text = MyWatcher.mainText;
        }
      
    }
