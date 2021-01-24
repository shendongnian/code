    namespace NinjectTest.AsyncFactory_44983826
    {
        using System;
        using System.Reflection;
        using System.Threading.Tasks;
        using Ninject;
        using Ninject.Extensions.Factory;
        using Ninject.Extensions.Factory.Factory;
        using FluentAssertions;
        using Xunit;
        public class AsyncInstanceProvider : StandardInstanceProvider
        {
            public override object GetInstance(IInstanceResolver instanceResolver, MethodInfo methodInfo, object[] arguments)
            {
                object result = base.GetInstance(instanceResolver, methodInfo, arguments);
                if (ReturnsTaskResult(methodInfo))
                {
                    return CreateFinishedTask(methodInfo, result);
                }
                return result;
            }
            protected override Type GetType(MethodInfo methodInfo, object[] arguments)
            {
                if (ReturnsTaskResult(methodInfo))
                {
                    return methodInfo.ReturnType.GenericTypeArguments[0];
                }
                return base.GetType(methodInfo, arguments);
            }
            private bool ReturnsTaskResult(MethodInfo methodInfo)
            {
                return (methodInfo.ReturnType.IsGenericType && methodInfo.ReturnType.GetGenericTypeDefinition() == typeof(Task<>));
            }
            private object CreateFinishedTask(MethodInfo methodInfo, object result)
            {
                var openGenericMethod = typeof(Task).GetMethod("FromResult");
                var closedGenericMethod = openGenericMethod.MakeGenericMethod(methodInfo.ReturnType.GenericTypeArguments[0]);
                return closedGenericMethod.Invoke(null, new object[1] { result });
            }
        }
        public class Foo
        {
            public string Id { get; private set; }
            public Bar Bar { get; private set; }
            public Foo(string id, Bar bar)
            {
                this.Id = id;
                this.Bar = bar;
            }
        }
        public class Bar { }
        public interface IFactory
        {
            Foo Create(string id);
            Task<Foo> CreateAsync(string id);
        }
        public class Test
        {
            [Fact]
            public void SyncTest()
            {
                var kernel = new StandardKernel();
                kernel
                    .Bind<IFactory>()
                    .ToFactory(() => new AsyncInstanceProvider());
                const string expectedId = "Hello You!";
                kernel.Get<IFactory>().Create(expectedId)
                    .Id.Should().Be(expectedId);
            }
            [Fact]
            public async Task AsyncTest()
            {
                var kernel = new StandardKernel();
                kernel
                    .Bind<IFactory>()
                    .ToFactory(() => new AsyncInstanceProvider());
                const string expectedId = "Hello You!";
                Foo result = await kernel.Get<IFactory>().CreateAsync(expectedId);
                result.Id.Should().Be(expectedId);
            }
        }
    }
