    namespace Test
    {
        public partial class MES : Form
        {
            public MES()
            {
                InitializeComponent();
            }
            private void Messen_Load(object sender, EventArgs e)
            {
                comboBox1.Items.Add("English");
                comboBox1.Items.Add("Deutsch");
                comboBox1.SelectedIndex = 0;
            }
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (comboBox1.SelectedItem.ToString() == "English")
                {
                   Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                    ChangeLanguage("en");
                }
                else
                {
                   Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
                    ChangeLanguage("de-DE");
                }
            }
            private void ChangeLanguage(string lang)
            {
                foreach (Control c in this.Controls)
                {
                    ComponentResourceManager resources = new ComponentResourceManager(typeof(Messen));
                    resources.ApplyResources(c, c.Name, new CultureInfo(lang));
                }
            }
            private void button2_Click(object sender, EventArgs e)
            {
                NewForm NF = new NewForm();
                NF.Show();
                this.Close();
            }
    }
