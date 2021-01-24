           var builder = new ContainerBuilder();
            builder.RegisterType<CancelScorable>()
                .As<IScorable<IActivity, double>>()
                .InstancePerLifetimeScope();
            builder.Update(Conversation.Container);`
