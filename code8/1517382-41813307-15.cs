    class ProgramGlobals
    {
        public String_Example Test {get; set; }
    }
    class Program
    {
        static void SetupFactory()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ProgramGlobals>().SingleInstance();
        }
        static void Main()
        {
            SetUpFactory();
            var globals = Container.Resolve<ProgramGlobals>();
            globals.Test = null;
        
            Form1 frm = new Form1();
            Application.Run(frm);
    
            MessageBox.Show(globals.Test._str);
        }
    }
    public partial class Form1: Form
    {
        private voide button1_Click(object sender, EventArgs e)
        {
            var globals = Container.Resolve<ProgramGlobals>();
            globals.Test._str = new String_Example(textbox1.Text)
        }
    }
