    public partial class EnvioContraseña: UserControl
    {
        public delegate void LoadOtherUserControl(EnvioContraseña sender);
        public event LoadOtherUserControl On_SelectButton;
        public EnvioContraseña()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (On_SelectButton != null)
                On_SelectButton(this);
        }
    }
