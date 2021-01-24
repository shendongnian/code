	public static class NinjectExtensions {
        public static IBindingNamedWithOrOnSyntax<T> InCallAndConnectionStringScope<T>(this IBindingInSyntax<T> syntax, Func<IContext, string> getConnString) {
            return syntax.InScope(context => {
                var connString = getConnString(context);
                var ScopeParameterName = $"NamedScopeInCallScope_{connString}";
                var rootContext = context;
                while (!IsCurrentResolveRoot(rootContext) && rootContext.Request.ParentContext != null) {
                    rootContext = rootContext.Request.ParentContext;
                }
                return GetOrAddScope(rootContext, ScopeParameterName);
            });
        }
        private static bool IsCurrentResolveRoot(IContext context) {
            return context.Request.GetType().FullName == "Ninject.Extensions.ContextPreservation.ContextPreservingResolutionRoot+ContextPreservingRequest";
        }
        private static object GetOrAddScope(IContext parentContext, string scopeParameterName) {
            var namedScopeParameter = GetNamedScopeParameter(parentContext, scopeParameterName);
            if (namedScopeParameter == null) {
                namedScopeParameter = new NamedScopeParameter(scopeParameterName);
                parentContext.Parameters.Add(namedScopeParameter);
            }
            return namedScopeParameter.Scope;
        }
        private static NamedScopeParameter GetNamedScopeParameter(IContext context, string scopeParameterName) {
            return context.Parameters.OfType<NamedScopeParameter>().SingleOrDefault(parameter => parameter.Name == scopeParameterName);
        } 
    }
