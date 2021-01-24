    public partial class ServerUser : Form
    {
    public ServerUser(Form1 form1)
    {
        InitializeComponent();
        form1.Preload();
    }
    public void LoadDocument()
    {
        ConfigureSource();
    }
    public void ConfigureSource()
    {
        InvokeUpdateControls();
    }
    public void InvokeUpdateControls()
    {
          UpdateControls();
    }
    private void UpdateControls()
    {
        richTextBox1.Rtf = Resource1.ReferatPPC_Bun___Copy;
    }
    }
    
    public partial class Form1 : Form
    {
    ServerUser server = null;
    public Form1()
    {
        InitializeComponent();
        Preload();
    }
    public async void Preload()
    {
      await  Task.Run(() =>
            {
                server = new ServerUser();
                server.LoadDocument();
                server.ShowDialog();
            }
        );
    }
    private void button1_Click(object sender, EventArgs e)
    {
        server=new ServerUser(this);// or whatever you want
        server.Show();
    }
    }
