    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Model : BindableBase
    {
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title != value)
                {
                    title = value;
                    NotifyPropertyChanged();
                }
            }
        }
       
    }
    public class ViewModel : BindableBase
    {
        private Model modelObj;
        public Model ModelObj
        {
            get
            {
                return modelObj;
            }
            set
            {
                modelObj = value;
                NotifyPropertyChanged();
            }
        }
        public ViewModel()
        {
            ModelObj = new Model();
            ModelObj.Title = "New title"; 
        }
    }
