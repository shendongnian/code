    private void sorted()
    {
      bool bubbleUp = true;
      string temp = "";
      while (bubbleUp)
      {
        // bubble up adjacent values
        bubbleUp = false;
        for (int i = 0; i < _ListBox.Items.Count - 1; i++)
        {
          if (CheckItem(_ListBox.Items[i].ToString()) > CheckItem(_ListBox.Items[i + 1].ToString()))
          {
            temp = _ListBox.Items[i].ToString();
            _ListBox.Items[i] = _ListBox.Items[i + 1];
            _ListBox.Items[i + 1] = temp;
            bubbleUp = true;
          }
        }
      }
    }
    //-------------------------------------------------------------------------
    private int CheckItem(string inItem)
    {
      int value;
      if (int.TryParse(inItem, out value))
        return value;
      return 0; 
    }
    //-------------------------------------------------------------------------
    private void button1_Click(object sender, EventArgs e)
    {
      sorted();
    }
