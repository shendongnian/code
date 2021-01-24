    private void AddItemSafe(string text)
    {
      if (this.InvokeRequired)
      {
        AddItemSafeCallback a = new AddItemSafeCallback(AddItemSafe);
        this.Invoke(a, new object[] { text });
      }
      else
      {
        // !!!!Note difference here:
        listmessage.Items.Add(text);
      }
    }
