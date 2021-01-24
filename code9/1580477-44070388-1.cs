    public class ModuleDefinition : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            const string smsSender = "SmsSender";
            builder.RegisterType<SmsSender>().As<ISender>().Named<ISender>(smsSender);
            builder.RegisterType<Bar>()
                .WithParameter((p, c) => p.Name == "sender", (p, c) => c.ResolveNamed<ISender>(smsSender));
        }
    }
