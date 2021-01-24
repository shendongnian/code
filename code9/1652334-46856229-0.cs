    public class Bindings : NinjectModule
        {
            public override void Load()
            {
                Bind<IConnectionToModbusCreator>().To<ConnectionToModbusCreator>();
                Bind<IInputProcessor>().To<InputProcessor>();
                Bind<ISequenceController>().To<SequenceController>();
                Bind<Form1>().ToSelf(); // in fact useless unless you add a scope, like .InSingletonScope()
            }
    }
    static class Program
        {
            [STAThread]
            static void Main()
            {
                var kernel = new StandardKernel();
                kernel.Load(Assembly.GetExecutingAssembly());
    
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var form1= kernel.Get<Form1>();
                Application.Run(form1);
    }
    public partial class Form1 : Form
    {
        private readonly ISequenceController _sequenceController;
        public Form1(ISequenceController sequenceController)
        {            
            _sequenceController = sequenceController;
            InitializeComponent();
        }
        private void Test_Click_1(object sender, EventArgs e)
        {
            _sequenceController.StartSequence();
        }
