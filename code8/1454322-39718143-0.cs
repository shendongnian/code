    public class MyViewModel
    {
        private readonly SubViewModel _subViewModel;
        public SubViewModel SubViewModel
        {
            get { return _subViewModel; }
        }
        public MyViewModel()
        {
            _subViewModel = new SubViewModel();
            _subViewModel.Text1 = "blabla";
        }
    }
    public class SubViewModel : DependencyObject
    {
        public string Text1
        {
            get { return (string)GetValue(Text1Property); }
            set { SetValue(Text1Property, value); }
        }
        public static readonly DependencyProperty Text1Property =
            DependencyProperty.Register("Text1", typeof(string), typeof(SubViewModel));
    }
