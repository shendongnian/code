    private List<Atleticar> GetData() {
      List<Atleticar> list = new List<Atleticar>();
      Atleticar atl = new Trkac("textBoxIme.Text1", "textBoxPrezime.Text1", 12);
      list.Add(atl);
      atl = new Trkac("textBoxIme.Text2", "textBoxPrezime.Text2", 1);
      list.Add(atl);
      atl = new Trkac("textBoxIme.Text3", "textBoxPrezime.Text3", 122);
      list.Add(atl);
      atl = new Trkac("textBoxIme.Text4", "textBoxPrezime.Text4", 99);
      list.Add(atl);
      atl = new Trkac("textBoxIme.Text5", "textBoxPrezime.Text5", 03);
      list.Add(atl);
      atl = new Trkac("textBoxIme.Text6", "textBoxPrezime.Text6", 67);
      list.Add(atl);
      atl = new Trkac("textBoxIme.Text7", "textBoxPrezime.Text7", -12);
      list.Add(atl);
      return list;
    }
    private void buttonGetData_Click(object sender, EventArgs e) {
      listBox1.Items.Clear();
      foreach (Atleticar a in GetData()) {
        listBox1.Items.Add(a);
      }
    }
    private void buttonSort_Click(object sender, EventArgs e) {
      List<Atleticar> list = new List<Atleticar>();
      foreach (Atleticar a in listBox1.Items) {
        list.Add(a);
      }
      list.Sort();
      listBox1.Items.Clear();
      foreach (Atleticar a in list) {
        listBox1.Items.Add(a);
      }
    }
