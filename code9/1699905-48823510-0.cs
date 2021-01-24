    public static class BindingExtension
    {
        public static IBindingToSyntax<TInterface> TrackObjects<TInterface>(this IBindingToSyntax<TInterface> self)
            where TInterface : class
        {
            
            self.Kernel.Bind<ObjectTracker<TInterface>>().ToSelf().InSingletonScope();
            self.BindingConfiguration.ActivationActions.Add((c, o) =>
            {
                c.Kernel.Get<ObjectTracker<TInterface>>().Add((TInterface)o);
            });
            return self;
        }
    }
    // Usage
    public class MyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMyInterface>()
                .TrackObjects()
                .To<MyImplementation>();//creates new instance on every Get<> call
        }
    }
    var a = kernel.Get<IMyInterface>();
    var b = kernel.Get<IMyInterface>();
    var c = kernel.Get<IMyInterface>();
    var abcList = kernel.Get<ObjectTracker<IMyInterface>>().AllInstances.ToList();
    // Helper class
    public class ObjectTracker<T>
        where T: class
    {
        private List<WeakReference<T>> instances = new List<WeakReference<T>>();
        public void Add(T item)
        {
            this.Prune(); // You could optimize how often you prune the list, with a counter for example.
            instances.Add(new WeakReference<T>(item));
        }
        public void Prune()
        {
            this.instances.RemoveAll(x => !x.TryGetTarget(out var _));
        }
        public IEnumerable<T> AllInstances => instances
            .Select(x =>
            {
                x.TryGetTarget(out var target);
                return target;
            })
            .Where(x => x != null);
    }
