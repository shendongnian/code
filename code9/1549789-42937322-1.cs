    public class MyPath
    {
        public string FullPath { get; private set; }
        public string Name '
        { 
            get { return Path.GetFileName(s) }             
        }
        public MyPath(string path)
        {
            FullPath = path;
        }
    }
    // Load and bind it to the ListBox
    var data = OpenFileDialog1.FileNames
                                .Select(path => new MyPath(path))
                                .ToList();
    // Name of the property which will be used for displaying text
    listBox1.DisplayMember = "Name"; 
    listBox1.ValueMember = "FullPath";
    listBox1.DataSource = data;
  
    private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
    {
        var selectedPath = (MyPath)ListBox1.SelectedItem;
        // Both name and full path can be accesses without second listbox
        // selectedPath.FullPath
        // selectedPath.Name
    }
