    public Dictionary<string, AClass> DGVDictionary;
    public DataTable DGVTable;
    public List<AClass> DGVList;
    public Form1() {
      InitializeComponent();
    }
    private Dictionary<string, AClass> GetDictionary() {
      Dictionary<string, AClass> dictionary = new Dictionary<string, AClass>();
      for (int key = 0; key < 15; key++) {
        AClass ac = new AClass();
        ac.data1 = "data1" + key;
        ac.data2 = "data2" + key;
        dictionary.Add(key.ToString(), ac);
      }
      return dictionary;
    }
    private void CreateTable() {
      DGVTable = new DataTable();
      DGVTable.Columns.Add("key", typeof(int));
      DGVTable.Columns.Add("data1", typeof(string));
      DGVTable.Columns.Add("data2", typeof(string));
    }
    private void FillDataTable() {
      for (int key = 0; key < 15; key++) {
        AClass ac = new AClass();
        ac.data1 = "data1" + key;
        ac.data2 = "data2" + key;
        DGVTable.Rows.Add(key, ac.data1, ac.data2);
      }
    }
    private List<AClass> FillList() {
      List<AClass> list = new List<AClass>();
      for (int key = 0; key < 15; key++) {
        AClass ac = new AClass();
        ac.key = key;
        ac.data1 = "data1" + key;
        ac.data2 = "data2" + key;
        list.Add(ac);
      }
      return list;
    }
     private void buttonDataTable_Click(object sender, EventArgs e) {
      // set up and fill left Data grid view using a DataTable
      CreateTable();
      FillDataTable();
      dataGridView1.DataSource = DGVTable;
      MessageBox.Show("DGV with a DataTable");
    }
    private void buttonList_Click(object sender, EventArgs e) {
      //setup and fill right Data grid view with list of AClass 
      DGVList = FillList();
      dataGridView1.DataSource = DGVList;
      MessageBox.Show("DGV with a List<AClass>");
    }
    private void buttonDictionary_Click(object sender, EventArgs e) {
      // setup and fill right Data grid view with list of AClass 
      DGVDictionary = GetDictionary();
      dataGridView1.DataSource = DGVDictionary.ToList();
      MessageBox.Show("DGV with a Dictionat<string, AClass>");
    }
    private void buttonClear_Click(object sender, EventArgs e) {
      dataGridView1.DataSource = null;
    }
