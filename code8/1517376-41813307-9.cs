    class ProgramGlobals
    {
        public String_Example Test {get; set; }
    }
    static void SetupFactory()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<ProgramGlobals>().InstancePerLifetimeScope();
    }
    static void Main()
    {
        SetUpFactory();
        var globals = Container.Resolve<ProgramGlobals>();
        globals.Test = new String_Example();
        ...
    }
    private voide button1_Click(object sender, EventArgs e)
    {
        var globals = Container.Resolve<ProgramGlobals>();
        globals.Test._str = new String_Example(textbox1.Text)
    }
