    public static class DependencyManager {
        private static Dictionary<Type, object> dependencies = new Dictionary<Type, object>();
    
        public static void AddDependency<TInterf, TImpl>(TImpl dependency)
            where TImpl : TInterf {
            dependencies[typeof(TInterf)] = dependency;
        }
    
        public static T GetDependency<T>() {
            T dependency;
            bool hasDependency = dependencies.TryGetValue(typeof(T), out dependency);
            if (hasDependency) {
                return dependency;
            }
            else {
                return default(T)
            }
        }
    }
