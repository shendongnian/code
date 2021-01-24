    using System;
    using System.Collections.Generic;
    using Xunit;
    using Autofac;
    using System.Reflection;
    namespace Tests
    {
    public class Tests
    {
        public class ClassUnderTest
        {
            public IContainer CreateContainer()
            {
                var builder = new Autofac.ContainerBuilder();
                builder.RegisterType<MyCommandHandler>().As<ICommandHandler<AnotherCommand>>();
                builder.RegisterType<MyCommandHandler>().As<ICommandHandler<MyCommand>>();
                builder.RegisterGeneric(typeof(CompositeCommandHandler<>)).As(typeof(ICommandHandler<>));
                return builder.Build();
            }
        }
        [Fact]
        public void Test1()
        {
            // arrange 
            var myClassUnderTest = new ClassUnderTest();
            var container = myClassUnderTest.CreateContainer();
            var myCommand = new MyCompositeCommand(new List<ICommand> { new MyCommand(), new AnotherCommand() });
            // act 
            Assert.IsType<MyCommandHandler>(container.Resolve<ICommandHandler<MyCommand>>());
            Assert.IsType<MyCommandHandler>(container.Resolve<ICommandHandler<AnotherCommand>>());
            var handler = container.Resolve<ICommandHandler<MyCompositeCommand>>();
            handler.Handle(myCommand);
        }
        public interface ICommand { }
        public interface ICompositeCommand : ICommand
        {
            IEnumerable<ICommand> Commands { get; }
        }
        public class MyCommand : ICommand { }
        public class AnotherCommand : ICommand { }
        public class MyCompositeCommand : ICompositeCommand
        {
            private readonly IEnumerable<ICommand> commands;
            public MyCompositeCommand(IEnumerable<ICommand> commands)
            {
                this.commands = commands;
            }
            public IEnumerable<ICommand> Commands { get { return commands; } }
        }
        public interface ICommandHandler<in T> where T : ICommand
        {
            void Handle(T command);
        }
        public class MyCommandHandler : ICommandHandler<MyCommand>, ICommandHandler<AnotherCommand>
        {
            public void Handle(MyCommand command)
            {
                Console.WriteLine("Handling MyCommand");
            }
            public void Handle(AnotherCommand command)
            {
                Console.WriteLine("Handling AnotherCommand");
            }
        }
        public class CompositeCommandHandler<CompositeCommand> : ICommandHandler<CompositeCommand> where CompositeCommand : ICompositeCommand
        {
            private Func<ICommand, ICommandHandler<ICommand>> _factory;
            private ILifetimeScope _container;
            public CompositeCommandHandler(ILifetimeScope container)
            {
                _container = container;
            }
            public void Handle(CompositeCommand command)
            {
                foreach (var myCommand in command.Commands)
                {
                    // resolve the specific command handler
                    var handler = ResolveMyHandler(myCommand);
                    // invoke the command handler
                    var handlerType = handler.GetType();
                    var handleMethod = handlerType.GetMethod(nameof(ICommandHandler<ICommand>.Handle),new []{myCommand.GetType()}); 
                    handleMethod.Invoke(handler, new[]{ myCommand}); 
                }
            }
            public object ResolveMyHandler(ICommand command)
            {
                var mySpecificHandlerType = command.GetType();
                var myGenericCommandHandlerType = typeof(ICommandHandler<>);
                var result = myGenericCommandHandlerType.MakeGenericType(new[] { mySpecificHandlerType });
                return _container.Resolve(result);
            }
        }
    }
}
