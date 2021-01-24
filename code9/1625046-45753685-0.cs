    public interface IViewModelFactory {
        ViewModel Create(Character model, bool arg2, bool arg2);
    }
    public class ViewModelFactory : IViewModelFactory {
        public ViewModel Create(Character model, bool arg2, bool arg3) {
            return new ViewModel(model, arg1, arg3);
        }
    }
