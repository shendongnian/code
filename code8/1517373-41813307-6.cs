    class ProgramGlobals
    {
        String_Example Test {get; set; }
    }
    static void SetupDI()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<ProgramGlobals>().InstancePerLifetimeScope();
    }
    static void Main()
    {
        SetUpDI();
        String_Example test = Container.Resolve<ProgramGlobals>();
        ...
    }
    private voide button1_Click(object sender, EventArgs e)
    {
        String_Example test = Container.Resolve<ProgramGlobals>();
        test._str = new String_Example(textbox1.Text)
    }
