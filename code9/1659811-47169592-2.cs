    namespace listoflist
    {
        public partial class Form1 : Form
        {
            public List<Record> rowList;
            public List<List<Record>> blockList;
    
            public BindingSource bs = new BindingSource();
            public Form1()
            {
                InitializeComponent();
    
                int rowListLength = 2;
                int blockListLength = 3;
                blockList = new List<List<Record>>(blockListLength);
                for (int i = 0; i < blockListLength; i++)
                {
                    blockList.Add(new List<Record>());
                    blockList[i] = new List<Record>(rowListLength);
                    for (int j = 0; j < rowListLength; j++)
                        blockList[i].Add(new Record(10 * i + j, "name_" + (10 * i + j).ToString()));
                }
    
                //dg.AutoGenerateColumns = false;
                //dg.Columns["ID"].ReadOnly = false;
                //dg.Columns["ID"].DataPropertyName = "ID";
                //dg.Columns["Customer"].DataPropertyName = "Customer";
    
                bs.DataSource = typeof(List<List<Record>>);
                foreach (List<Record> block in blockList)
                    bs.Add(block);
                bs.CurrencyManager.Position = 0;
                dg.DataSource = (List<Record>)bs.CurrencyManager.Current;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
    
            private void numUpDown_ValueChanged(object sender, EventArgs e)
            {
                bs.CurrencyManager.Position = (int)numUpDown.Value;
                dg.CurrentCell = dg.Rows[Math.Min(dg.CurrentRow.Index + bs.CurrencyManager.Position, dg.Rows.Count - 1)].Cells[dg.CurrentCell.ColumnIndex];
               
            }
        }
    
        public class Record
        {
            public Record(int id, string customer)
            {
                ID = id;
                Customer = customer;
            }
            public Decimal? ID { get; set; }
            public string Customer { get; set; }
        } 
    }
