    [Designer(typeof(OuterControlDesigner))]
    public partial class OuterControl : UserControl
    {
        public OuterControl()
        {
            InitializeComponent();
        }
        public InnerControl InnerControl { get { return innerControl1; } }
    }
    public class OuterControlDesigner:ControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            this.EnableDesignMode(((OuterControl)this.Control).InnerControl, "InnerControl");
        }
    }
