    public partial class Form1 : Form
    {
        // BindingList is perfect here... istead of List. It automatically refreshes upon change.
        private BindingList<Test> m_Tests;
        public Form1()
        {
            InitializeComponent();
            m_Tests = new BindingList<Test>();
            listBox1.DataSource = m_Tests;
            // DisplayMember and ValueMember should be defined too here.
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new instance every time the button is clicked.
            // Since textBox1.Text is already a String... no need to convert it!
            // Thanks to BindingList, you don't need to refresh your binding...
            m_Tests.Add(new Test(textBox1.Text));
        }
    }
    public class Test
    {
        private String m_Name;
        public String Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        public Test(String name)
        {
            m_Name = name;
        }
        public override String ToString()
        {
            return (m_Name + "   " + m_Name);
        }
    }
