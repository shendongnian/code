    public partial class Form1 : Form
    {
        public class DtoObj
        {
            public string Field1 { get; set; }
            public int Field2 { get; set; }
            public bool IsSelected { get; set; }
        }
        private BindingList<DtoObj> gridValues;
        public Form1()
        {
            InitializeComponent();
            gridValues = new BindingList<DtoObj>() {
                new DtoObj() { Field1 = "#1", Field2 = 1 },
                new DtoObj() { Field1 = "#2", Field2 = 2 },
                new DtoObj() { Field1 = "#3", Field2 = 3 },
                new DtoObj() { Field1 = "#4", Field2 = 4 },
            };
            dataGridView1.DataSource = gridValues;
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var objectsToRemove = gridValues.Where(o => o.IsSelected).ToList();
            foreach (var idx in objectsToRemove)
                gridValues.Remove(idx);
        }
    }
