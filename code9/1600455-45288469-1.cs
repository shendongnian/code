    private readonly MouseHookListener m_MouseHookManager;
    public Form1()
    {
         InitializeComponent();
         m_MouseHookManager = new MouseHookListener(new GlobalHooker());
         m_MouseHookManager.Enabled = true;
         m_MouseHookManager.MouseClick += m_mouseHookListener_Coordinates;
               
    }
    private void m_mouseHookListener_Coordinates(object sender, MouseEventArgs e)
    {
         MessageBox.Show(this,"Coordinate X:"+e.X +" Coordinate Y:"+e.Y,"Coordinates",MessageBoxButtons.OK,MessageBoxIcon.Information);
    }
