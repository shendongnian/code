    using System;
    using Castle.MicroKernel.Registration;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var container = new Castle.Windsor.WindsorContainer();
                container.Register(Component.For<IFoo>().ImplementedBy<Foo>());
                container.Register(Component.For<ISomethingElse>().ImplementedBy<SomethingElse>());
    
                container.Register(Component.For<IBar>().ImplementedBy<Bar>().LifeStyle.Transient);
    
                container.Register
                (
                    Component
                    .For<IBaz>()
                    .UsingFactoryMethod
                    (
                        (k, c) =>
                        {
                            IBaz resolved = null;
                            var requestingType = c.Handler.ComponentModel.Implementation;
                            if (requestingType == typeof(Foo))
                            {
                                resolved = new Baz();
                            }
                            else
                            {
                                resolved = new BazSpecial();
                            }
    
                            return resolved;
                        }
                    ).LifeStyle.Transient
                );
    
                var f = container.Resolve<IFoo>();
                var se = container.Resolve<ISomethingElse>();
    
                Console.ReadLine();
            }
        }
        internal interface IBar
        {
        }
    
        internal interface IBaz
        {
        }
    
        internal interface IFoo
        {
        }
    
        interface ISomethingElse
        {
    
        }
    
    
        internal class Bar : IBar
        {
            private readonly IBaz baz;
    
            public Bar(IBaz baz)
            {
                this.baz = baz;
            }
    
        }
    
        internal class Baz : IBaz
        {
        }
    
        internal class BazSpecial : IBaz
        {
        }
    
        internal class Foo : IFoo
        {
            private readonly IBar bar;
    
            public Foo(IBar bar)
            {
                this.bar = bar;
            }
        }
    
        internal class SomethingElse : ISomethingElse
        {
            private readonly IBar bar;
    
            public SomethingElse(IBar bar)
            {
       
    
             this.bar = bar;
            }
        }
    }}
    
     
