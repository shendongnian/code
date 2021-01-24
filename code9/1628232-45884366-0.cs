    private void btnDown_Click(object sender, EventArgs e) {
      listBox1.BeginUpdate();
      int[] indexes = listBox1.SelectedIndices.Cast<int>().ToArray();
      if (indexes.Length > 0 && indexes[indexes.Length - 1] < listBox1.Items.Count - 1) {
        for (int i = listBox1.Items.Count - 1; i > -1; --i) {
          if (indexes.Contains(i)) {
            object moveItem = listBox1.Items[i];
            listBox1.Items.Remove(moveItem);
            listBox1.Items.Insert(i + 1, moveItem);
            listBox1.SetSelected(i + 1, true);
          }
        }
      }
      listBox1.EndUpdate();
    }
    private void btnUp_Click(object sender, EventArgs e) {
      listBox1.BeginUpdate();
      int[] indexes = listBox1.SelectedIndices.Cast<int>().ToArray();
      if (indexes.Length > 0 && indexes[0] > 0) {
        for (int i = 0; i < listBox1.Items.Count; ++i) {
          if (indexes.Contains(i)) {
            object moveItem = listBox1.Items[i];
            listBox1.Items.Remove(moveItem);
            listBox1.Items.Insert(i - 1, moveItem);
            listBox1.SetSelected(i - 1, true);
          }
        }
      }
      listBox1.EndUpdate();
    }
