    public partial class UserControl1 : UserControl
    {
        [Browsable(true)]
        [Description("Select some.")]
        [Category("Selection Test"), DisplayName("Bool List")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<BoolProperty> BoolList { get; set; } = new List<BoolProperty>();
        public UserControl1()
        {
            InitializeComponent();
        }
    }
    [Serializable]
    public class BoolProperty
    {
        public string Name { get; set; }
        public bool Value { get; set; }
        public override string ToString()
        {
            return Name ?? "Empty Boolean Property";
        }
    }
