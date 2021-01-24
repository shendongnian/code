    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class MyControl : UserControl
    {
        private const string MyDefaultFont = "Tahoma, 10pt";
        public MyControl()
        {
            InitializeComponent();
            this.Font = (Font)new FontConverter().ConvertFromString(MyDefaultFont);
        }
        [DefaultValue(typeof(Font), MyDefaultFont)]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }
    }
