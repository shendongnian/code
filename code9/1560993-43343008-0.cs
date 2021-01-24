    public delegate void ColorChangeEventHandler();
    public partial class myControl: UserControl
    {
        
        public event ColorChangeEventHandler ColorChanged;
        private void OnColorChange()
        {
            if(ColorChanged != null)
            {
                ColorChanged.Invoke();
            }
        }
        public speelRij()
        {
            InitializeComponent();
        }
      private void Button1_Click(object sender, EventArgs e)
        {
            OnColorChange();
            Control ctrl = ((Control)sender);
            switch (ctrl.BackColor.Name)
            {
                case "Crimson": ctrl.BackColor = Color.Blue; break;
                case "Green": ctrl.BackColor = Color.Orange; break;
                case "Orange": ctrl.BackColor = Color.Crimson; break;
                case "Blue": ctrl.BackColor = Color.Green; break;
                default: ctrl.BackColor = Color.Crimson; break;
            }
