    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Beta_DatabaseEntities db = new Beta_DatabaseEntities();
        table1 tb = new table1();
        public int ID;
        public string Name;
        public int Salary;
        public void Entry()
        {
            ID = Convert.ToInt16(id.Text);
            Name = name.Text;
            //Salary = Convert.ToInt32(salary.Text);
            tb.Id = ID;
            tb.Name = Name;
            //tb.Salary = Salary;
        }
        private void update_Click(object sender, EventArgs e)
        {tb=db.Tables.where(x=>x.id==1).firstOrDefault();
            Entry();
            db.SaveChanges();
            MessageBox.Show("UPDATED");
        }
    }
}
