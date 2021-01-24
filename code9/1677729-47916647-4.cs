    public Form1()
    {
       InitializeComponent();
       values.DragDrop += new DragEventHandler(this.OnDrop);
       values.DragEnter += new DragEventHandler(this.OnDragEnter);
    }
    
    public async void OnDrop(object sender, DragEventArgs e)
    {
       string dropped = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
       if (dropped.Contains(".csv") || dropped.Contains(".txt")) {
          try {
             string line = string.Empty;
             using (var reader = new StreamReader(dropped)) {
                while (reader.Peek() >= 0) {
                   line = await reader.ReadLineAsync();
                   values.AppendText(line.Replace(";", " ") + "\r\n");
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
       e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop, false) 
                ? DragDropEffects.Copy 
                : DragDropEffects.None;
    }
