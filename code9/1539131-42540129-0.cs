    List<string> items = new List<string>();
    int count = 0;
    foreach (string s in yourData.Split(';')) {
      count++;
      if (count == 15) {
        items.Add(s);
        count = 1;
      }
    }
    MessageBox.Show(string.Join(Environment.NewLine, items.ToArray()));    
