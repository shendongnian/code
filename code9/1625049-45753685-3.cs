    public interface IViewModelFactory {
        T CreateNew<T>(params object[] args) where T : ViewModelBase;
    }
    public class ViewModelFactory : IViewModelFactory {
        public T CreateNew<T>(params object[] args) where T : ViewModelBase {
            return (T)Activator.CreateInstance(typeof(T), args);
        }
    }
    public class ViewModelBase { }
