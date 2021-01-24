    public class ModuleDefinition : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            const string emailSender = "EmailSender";
            builder.RegisterType<EmailSender>().As<ISender>().Named<ISender>(emailSender);
            builder.RegisterType<Foo>()
                .WithParameter((p, c) => p.Name == "sender", (p, c) => c.ResolveNamed<ISender>(emailSender));
        }
    }
