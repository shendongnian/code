    public interface IWizardPage { }
    public class Page1ViewModel : ViewModelBase, IWizardPage { }
    public class Page2ViewModel : ViewModelBase, IWizardPage { }
    public class Page3ViewModel : ViewModelBase, IWizardPage { }
    public class MainPageViewModel : ViewModelBase
    {
        public IWizardPage CurrentPage { get; set; }
        public IWizardPage Page1ViewModel { get; set; }
        public IWizardPage Page2ViewModel { get; set; }
        public IWizardPage Page3ViewModel { get; set; }
    }
