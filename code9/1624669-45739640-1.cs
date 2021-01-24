    public partial class Profiler : Window
    {
        private DspWindow dspWindow;    
    
        public Profiler(DspWindow dspWindow)
        {
            InitializeComponent();
            this.dspWindow = dspWindow;
        }
    
        void DoSomething() 
        {
            int numberOfPaperRolls = dspWindow.PaperRolls.Count; //you can access the list in this object aswell!
        }
    }
