    public partial class Form2 : Form
    {
        List<Inventory> inventory;
        public Form2()
        {
            InitializeComponent();
        }
        public void ReadFiles()
        {
            if (inventory == null)
                inventory = new List<Inventory>();
            using (TextReader r = new StreamReader("file.txt"))
            {
                string line = null;
                while ((line = r.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    Inventory obj = new Inventory();
                    obj.Name = fields[0];
                    obj.Qtd = Convert.ToInt32(fields[1]);
                    obj.Price = Convert.ToInt32(fields[2]);
                    inventory.Add(obj);
                }
            }
            SetDataSourceList();
        }
        public void SetDataSourceList()
        {
            listBox1.DisplayMember = "Name";
            listBox2.DisplayMember = "Qtd";
            listBox3.DisplayMember = "Price";
            listBox1.DataSource =
                listBox2.DataSource = 
                listBox3.DataSource =
                inventory;
        }
    }
    public class Inventory
    {
        public string Name { get; set; }
        public int Qtd { get; set; }
        public decimal Price { get; set; }
    }
