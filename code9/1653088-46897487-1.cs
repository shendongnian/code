       [Test]
        public void UnitOfWork()
        {
            var builder = new ContainerBuilder();
    
            builder.RegisterType<MessageCommandHandler>().As<IHandler<Message>>().InstancePerLifetimeScope();
            builder.RegisterType<MessageCommandHandler2>().As<IHandler<Message>>().InstancePerLifetimeScope();
    
            builder.RegisterGeneric(typeof(UnitOfWorkDecorator<,>)).AsSelf().SingleInstance();
    
            var container = builder.Build();
    
            var handler = container.Resolve<IHandler<Message>>();
    
            var uow = container.Resolve<UnitOfWorkDecorator<Message, IHandler<Message>>>();
            uow.Handle(new Message());
    
        }
