    using System.Windows;
    namespace WpfApp1
    {
      public class Test
      {
        public static readonly DependencyProperty aProperty
          = DependencyProperty.RegisterAttached ( "a",
                                                  typeof(int),
                                                  typeof(Test),
                                                  new PropertyMetadata(0) ) ;
        public static int Geta ( DependencyObject obj )
        {
          return (int)obj.GetValue(aProperty);
        }
        public static void Seta ( DependencyObject obj, int value )
        {
          obj.SetValue(aProperty, value);
        }
      }
    }
