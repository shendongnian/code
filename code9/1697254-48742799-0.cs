    public partial class ProgressView : ContentView
    {
        public double Progress
        {
            set { SetValue(ProgressProperty, value); }
            get { return (double)GetValue(ProgressProperty); }
        }
    
        public readonly static BindableProperty ProgressProperty = BindableProperty.Create("Progress", typeof(double), typeof(ProgressView), 0.0);
    
        ...
    }
