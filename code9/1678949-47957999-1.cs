    public partial class PhrasesFrame : Frame {
        public PhrasesFrameViewModel vm;
    
        public PhrasesFrame() {
            InitializeComponent();
            vm = new PhrasesFrameViewModel(this);
        }
