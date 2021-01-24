    public Form1()
    {
       InitializeComponent();
       values.DragDrop += new DragEventHandler(this.OnDrop);
       values.DragEnter += new DragEventHandler(this.OnDragEnter);
    }
    
    public async void OnDrop(object sender, DragEventArgs e)
    {
       string _dropped = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
       if (_dropped.Contains(".csv") || _dropped.Contains(".txt"))
       {
          try
          {
             string _s = string.Empty;
             using (TextReader tr = new StreamReader(_dropped))
             {
                while (tr.Peek() >= 0)
                {
                   _s = await tr.ReadLineAsync();
                   values.AppendText(_s.Replace(";", " ") + "\r\n");
                   await Task.Delay(10);
                }
             }
          }
          catch (Exception) {
             //Do something here
          }
       }
    }
    
    private void OnDragEnter(object sender, DragEventArgs e)
    {
       e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop, false) ?
                                        DragDropEffects.Copy :
                                        DragDropEffects.None;
    }
