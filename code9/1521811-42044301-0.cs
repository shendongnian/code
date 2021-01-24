     public sealed partial class Diagramer : UserControl
    {
        ViewModels.DiagramVM vm = null;
        public Diagramer()
        {
            this.InitializeComponent();
            vm = new ViewModels.DiagramVM();
            this.DataContext = vm;
            vm.DiagramUpdated += (s, e) =>
            {                
                DG1.LayoutManager.RefreshFrequency = RefreshFrequency.ArrangeParsing;
            };
            
        }
       
    }
