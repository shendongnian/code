    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace SO40564064
    {
      public class MyImageBorder : Border
      {
        public MyImageBorder()
        {
          IsMouseDirectlyOverChanged += MyImageBorder_IsMouseDirectlyOverChanged;
        }
    
        public bool IsMouseOverMe
        {
          get { return (bool)GetValue(IsMouseOverMeProperty); }
          set { SetValue(IsMouseOverMeProperty, value); }
        }
    
        public static readonly DependencyProperty IsMouseOverMeProperty =
            DependencyProperty.Register("IsMouseOverMe", typeof(bool), typeof(MyImageBorder), new PropertyMetadata(false));
    
        private void MyImageBorder_IsMouseDirectlyOverChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
          IsMouseOverMe = (bool)e.NewValue;
        }
      }
    }
