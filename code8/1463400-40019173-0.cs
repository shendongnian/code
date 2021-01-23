    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            IKeyboardHandlerService oldKeyboardHandler = (IKeyboardHandlerService)schedulerControl1.GetService(typeof(IKeyboardHandlerService));
            if (oldKeyboardHandler != null)
            {
                MyKeyboardHandlerService newKeyboardHandler = new MyKeyboardHandlerService(schedulerControl1, oldKeyboardHandler);
                schedulerControl1.RemoveService(typeof(IKeyboardHandlerService));
                schedulerControl1.AddService(typeof(IKeyboardHandlerService), newKeyboardHandler);
            }
        }
    }
    
    public class MyKeyboardHandlerService : KeyboardHandlerServiceWrapper
    {
        IServiceProvider provider;
    
        public MyKeyboardHandlerService(IServiceProvider provider, IKeyboardHandlerService service)
            : base(service)
        {
            this.provider = provider;
        }
    
        public override void OnKeyDown(KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.Left|| e.KeyCode == Keys.Right))
                            base.OnKeyDown(e);
        }
    }
