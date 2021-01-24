    public interface ITC
    {
        bool CanSave(object parameter);
    }
    public class OP: CM, ITC
    {
        public bool CanSave(object parameter) 
        {
            ...
        }
    }
