    using System;
    using System.Linq;
    using Ninject.Activation;
    using Ninject.Infrastructure.Language;
    using Ninject.Syntax;
    
    namespace Weingartner.Controls.PluginFramework
    {
        public static class NinjectExtensions
        {
    
            /// <summary>
            /// Indicates that the binding should only be used where the source 
            /// has been injected into parentChain[0] which in turn has been injected 
            /// into parentChain[1] and son on
            /// </summary>
            /// <param name="parentChain">This list of parents in order</param>
            /// <returns>The fluent syntax.</returns>
            public static IBindingInNamedWithOrOnSyntax<T> 
                WhenInjectedIntoRequestChain<T>
                    ( this IBindingWhenInNamedWithOrOnSyntax<T> @this
                    , params Type[] parentChain
                    )
            {
    
                @this.BindingConfiguration.Condition =
                    request =>
                    {
                        var result = true;
                        foreach (var parent in parentChain)
                        {
                            result = result && WhenInjectedInto(request, parent);
                            request = request?.ParentRequest;
                        }
                        return result;
                    };
    
                return (IBindingInNamedWithOrOnSyntax<T>)@this;
            }
    
            private static bool WhenInjectedInto(IRequest request, Type parent)
            {
                if (!parent.IsGenericTypeDefinition)
                    return request?.Target != null 
                        && parent.IsAssignableFrom(request.Target.Member.ReflectedType);
    
                if (!parent.IsInterface)
                    return request
                        ?.Target?.Member.ReflectedType
                        .GetAllBaseTypes()
                        .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == parent) ?? false;
    
                return request
                    ?.Target?.Member.ReflectedType?
                    .GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == parent) ?? false;
            }
        }
    }
