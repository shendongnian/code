    protected override void OnKeyDown(KeyEventArgs e)
      {
           if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
           {
            //This is the name of your gridview.. just for show
           DataGridView dv = new DataGridView();
            // Your array of the clipboard.. for show
           string[] clipboardlines = new string[2];
               foreach(string line in clipboardlines)
               {
                 this.dv.Rows.Add(line);
               }
           }
          base.OnKeyDown(e);
        }
