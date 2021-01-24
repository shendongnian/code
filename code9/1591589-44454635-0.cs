    public partial class TextBrowse : UserControl
    {
    public static readonly DependencyProperty SetName =DependencyProperty.Register("BlockName", typeof(string), typeof(TextBrowse),new PropertyMetadata(null); 
    public string BlockName
    {
       get { return (string)GetValue(SetName); }
       set { SetValue(SetName, value); }
    }
    private Type _T;
    public Type T
    {
       set { _T = value; }
       get { return _T; }
    }
    public enum Type { File, Folder }
    public TextBrowse()
    {
       InitializeComponent();
    }
    private void CButton_Click(object sender, RoutedEventArgs e)
    {
       if (_T == Type.File)
       {
              OpenFileDialog ofd = new OpenFileDialog();
              if (ofd.ShowDialog() == DialogResult.OK)
                 this.DirectoryName = ofd.FileName;
        }
      else
      {
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        if (fbd.ShowDialog() == DialogResult.OK)
            CTextbox.Text = fbd.SelectedPath;
       }
    }
    public string DirectoryName
    {
        get
        {
           return (string)this.GetValue(DirectoryNameProperty);
        }
        set
        {
           this.SetValue(DirectoryNameProperty, value);
        }
    }
    public static readonly DependencyProperty DirectoryNameProperty =DependencyProperty.Register("TextName", typeof(string), typeof(TextBrowse), new PropertyMetadata(""));}
