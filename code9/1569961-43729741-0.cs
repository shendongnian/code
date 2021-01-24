    using System;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    namespace ConsoleApp1
    {
        public class Foo
        {
            public string Title => "Foo title";
        }
        public class Bar
        {
            public string Name => "Foo name";
        }
        public interface ITypeStringFormattingService<in T>
        {
            string FormatValue(T value);
        }
        public class FooStringFormattingService : ITypeStringFormattingService<Foo>
        {
            public string FormatValue(Foo value)
            {
                return value.Title;
            }
        }
        public class BarStringFormattingService : ITypeStringFormattingService<Bar>
        {
            public string FormatValue(Bar value)
            {
                return value.Name;
            }
        }
        public class UniversalFormatter : ITypeStringFormattingService<object>
        {
            private readonly IWindsorContainer _container;
            public UniversalFormatter(IContainerAccessor container)
            {
                _container = container.Container;
            }
            public string FormatValue(object value)
            {
                dynamic formatter = _container.Resolve(typeof(ITypeStringFormattingService<>).MakeGenericType(value.GetType()));
                return formatter.FormatValue((dynamic) value);
            }
        }
        public class ContainerAccessor : IContainerAccessor
        {
            public ContainerAccessor(IWindsorContainer container)
            {
                Container = container;
            }
            public IWindsorContainer Container { get; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var container = new WindsorContainer();
                container.Register(Component.For<IContainerAccessor>().Instance(new ContainerAccessor(container)));
                container.Register(Component.For(typeof(ITypeStringFormattingService<Foo>)).ImplementedBy<FooStringFormattingService>());
                container.Register(Component.For(typeof(ITypeStringFormattingService<Bar>)).ImplementedBy<BarStringFormattingService>());
                container.Register(Component.For(typeof(ITypeStringFormattingService<object>)).ImplementedBy<UniversalFormatter>());
                // Resolving
                var formatter = container.Resolve<ITypeStringFormattingService<object>>();
                object obj = new Bar();
                Console.WriteLine(formatter.FormatValue(obj));
                obj = new Foo();
                Console.WriteLine(formatter.FormatValue(obj));
            }
        }
    }
