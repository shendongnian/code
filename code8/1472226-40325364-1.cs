    using FluentAssertions;
    using Ninject;
    using Ninject.Activation;
    using Ninject.Syntax;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    namespace NinjectTest.SO40310046
    {
        public interface IBaseBL<TEntity>
            where TEntity : class
        { }
        public class BaseBL<TEntity> : IBaseBL<TEntity>
            where TEntity : class
        { }
        public class SimpleEntity { }
        public class BaseLogAuditoriaEntity
        { }
        public class ChildBaseLogAuditorialEntity: BaseLogAuditoriaEntity
        { }
        public class BaseLogAuditoriaBL<TEntity> : BaseBL<TEntity>, IBaseBL<TEntity>
            where TEntity: BaseLogAuditoriaEntity
        { }
        public static class BaseBLBindingExtensions
        {
            public static IBindingInNamedWithOrOnSyntax<object> WhenEntityMatchesType<TEntityType>(this IBindingWhenSyntax<object> syntax)
            {
                return syntax.When(request => DoesEntityMatchType(request, typeof(TEntityType)));
            }
            private static bool DoesEntityMatchType(IRequest request, Type typeToMatch)
            {
                return typeToMatch.IsAssignableFrom(request.Service.GenericTypeArguments.Single());
            }
        }
        public class UnitTest
        {
            [Fact]
            public void Test()
            {
                var kernel = new StandardKernel();
                kernel.Bind(typeof(IBaseBL<>)).To(typeof(BaseBL<>));
                kernel.Bind(typeof(IBaseBL<>)).To(typeof(BaseLogAuditoriaBL<>))
                    .WhenEntityMatchesType<BaseLogAuditoriaEntity>();
                kernel.Get<IBaseBL<SimpleEntity>>()
                    .Should().BeOfType<BaseBL<SimpleEntity>>();
                kernel.Get<IBaseBL<BaseLogAuditoriaEntity>>()
                    .Should().BeOfType<BaseLogAuditoriaBL<BaseLogAuditoriaEntity>>();
                kernel.Get<IBaseBL<ChildBaseLogAuditorialEntity>>()
                    .Should().BeOfType<BaseLogAuditoriaBL<ChildBaseLogAuditorialEntity>>();
            }
        }
    }
