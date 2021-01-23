    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SomeClassName sc1 = new SomeClassName();
            sc1.ID = 411;
            sc1.Name = "Information";
            listBox1.Items.Add(sc1);
            SomeClassName sc2 = new SomeClassName();
            sc2.ID = 911;
            sc2.Name = "Emergency";
            listBox1.Items.Add(sc2);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                SomeClassName sc = (SomeClassName)listBox1.Items[listBox1.SelectedIndex];
                label1.Text = "ID: " + sc.ID.ToString();
                label2.Text = "Name: " + sc.Name;
            }
        }
    }
    public class SomeClassName
    {
        public int ID;
        public string Name;
        public override string ToString()
        {
            return ID.ToString() + ": " + Name;
        }
    }
