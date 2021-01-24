    Dictionary<int, string> comboBoxData = new Dictionary<int, string>(); 
    public Form1() {
      InitializeComponent();
      comboBoxData = GetDataDictionary();
      comboBox1.DataSource = new BindingSource(comboBoxData, null);
      comboBox1.DisplayMember = "Value";
      comboBox1.ValueMember = "Key";
    }
    private void SetSelectedIndex(int indexToSelect) {
      if (comboBoxData.Keys.Contains(indexToSelect)) {
        comboBox1.SelectedIndex = indexToSelect;
      }
      else {
        MessageBox.Show("The supplied key does not exist!");
      }
    }
    private Dictionary<int, string> GetDataDictionary() {
      Dictionary<int, string> dictionary = new Dictionary<int, string>();
      for (int i = 0; i < 15; i++) {
        dictionary.Add(i, "Item name " + i);
      }
      return dictionary;
    }
    private void buttonSelectIndex_Click(object sender, EventArgs e) {
      if (tbIndexToSelect.Text != "") {
        int indexToSelect = comboBox1.SelectedIndex;
        if (int.TryParse(tbIndexToSelect.Text, out indexToSelect)) {
          SetSelectedIndex(indexToSelect);
        }
      }
    }
