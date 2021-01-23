    public override void Install(IDictionary stateSaver)
    {
        var foo = Context.Parameters["foo"];
        Console.WriteLine($"Foo is {foo}");
        if (foo.Equals("bar"))
        {
            Console.WriteLine("Installing Service1");
            this.Installers.Remove(serviceInstaller2);
            base.Install(stateSaver);
        }
        else if (foo.Equals("baz"))
        {
            Console.WriteLine("Installing Service2");
            this.Installers.Remove(serviceInstaller1);
            base.Install(stateSaver);
        }
    }
