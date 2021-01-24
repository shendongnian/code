     public class ViewService<T> where T : IControlView
        {
            private readonly List<WeakReference> cache;
    
            public delegate void ShowDelegate(T ResultView);
            public event ShowDelegate Show;
            public void ShowControl<Z>(INotifyPropertyChanged ViewModel)
            {
                if (Show != null)
                    Show(GetView<Z>(ViewModel));
            }
    
            #region Singleton
    
            private static ViewService<T> instance;
            public static ViewService<T> GetContainer
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new ViewService<T>();
                    }
                    return instance;
                }
            }
    
            private ViewService()
            {
                cache = new List<WeakReference>();
                var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(r => typeof(T).IsAssignableFrom(r) && !r.IsInterface && !r.IsAbstract && !r.IsEnum);
    
                foreach (Type type in types)
                {
                    cache.Add(new WeakReference((T)Activator.CreateInstance(type)));
                }
            }
    
            #endregion
    
            private T GetView<Z>(INotifyPropertyChanged ViewModel)
            {
                T target = default(T);
                foreach (var wRef in cache)
                {
                    if (wRef.IsAlive && wRef.Target.GetType().IsEquivalentTo(typeof(Z)))
                    {
                        target = (T)wRef.Target;
                        break;
                    }
                }
    
                if(target.Equals(default(T)))
                    target = (T)Activator.CreateInstance(typeof(Z));
    
                if(ViewModel != null)
                    target.ViewModel = ViewModel;
    
                return target;
            }
    
        }
