    public class InjectionInterceptor : IInterceptor {
        private readonly ILifetimeScope _Scope;
        public InjectionInterceptor(ILifetimeScope scope) {
            _Scope = scope;
        }
        public void Intercept(IInvocation invocation) {
            using (var lifetime = _Scope.BeginLifetimeScope(string.Format("InjectionInterceptor {0}", Guid.NewGuid()))) {
                InjectDependencyIfNecessary(invocation, lifetime);
                invocation.Proceed();
            }
        }
        private void InjectDependencyIfNecessary(IInvocation invocation, ILifetimeScope lifetime) {
            int indexOfDependencyArgument = FindDependencyArgument(invocation.Method);
            if (indexOfDependencyArgument >= 0 && invocation.GetArgumentValue(indexOfDependencyArgument) == null) {
                SetDependencyArgument(invocation, indexOfDependencyArgument, lifetime);
            }
        }
        private static int FindDependencyArgument(System.Reflection.MethodInfo method) {
            var allArgs = method.GetParameters();
            return Array.FindIndex(allArgs, param =>
                param.ParameterType.IsInterface &&
                param.ParameterType.IsGenericType &&
                param.ParameterType.GetGenericTypeDefinition() == typeof(IGeneric<>));
        }
        private void SetDependencyArgument(IInvocation invocation, int indexOfDependencyArgument, ILifetimeScope lifetime) {
            var methodArg = invocation.Method.GetGenericArguments().Single();
            var dependency = lifetime.Resolve(typeof(IGeneric<>).MakeGenericType(methodArg));
            invocation.SetArgumentValue(indexOfDependencyArgument, dependency);
        }
    }
