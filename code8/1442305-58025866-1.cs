    using System.linq;
    public MyFormConstructor()
    {
        InitializeComponent();
        VScrollBar scrollBar = dgv.Controls.OfType<VScrollBar>().First();
        scrollBar.EndScroll += MyEndScrollEventHandler;
    }
    private void MyEndScrollEventHandler(object sender, ScrollEventArgs e)
    {
       // Handler with e.Type set properly
    }
