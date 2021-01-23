     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModelCombine VMC = new ViewModelCombine();
            VMC.VP.Add(new ViewModelPulse() { ID = 1, Name = "test1", xaxa = "xaxa" });
            VMC.VT.Add(new ViewModelTherapy() { ID = 2 Name = "test2", Description = "desc" });
            this.DataContext = VMC;
        }
        
    }
    public class ViewModelCombine
    {
        public ObservableCollection<ViewModelTherapy> VT { get; set; }
        public ObservableCollection<ViewModelPulse>  VP { get; set; }
        public ViewModelCombine()
        {
            VT = new ObservableCollection<ViewModelTherapy>();
            VP = new ObservableCollection<ViewModelPulse>();
        }
    }
    public class ViewModelTherapy
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class ViewModelPulse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string xaxa { get; set; }
    }
